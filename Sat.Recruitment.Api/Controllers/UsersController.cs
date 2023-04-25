using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Adpaters;
using Sat.Recruitment.Api.Entities;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        public UsersController()
        {
        }

        [HttpPost]
        [Produces(typeof(User))]
        public async Task<ActionResult> CreateUser([FromBody] User newUser)
        {

            try
            {
                var errors = newUser.ValidateErrors();

                if (!string.IsNullOrEmpty(errors))
                    return BadRequest(new Result { IsSuccess = false, Errors = errors });

                DataAccess.SaveUserToFile(newUser);

                Debug.WriteLine("User Created");
                return new OkObjectResult(
                    new Result()
                    {
                        IsSuccess = true,
                        Errors = "User Created"
                    }
                );
            }
            catch (Exception ex)
            {
                Debug.WriteLine("User was no able to save error: " + ex.Message);
                return BadRequest(new Result { IsSuccess = false, Errors = ex.Message });
            }
        }
    }

}
