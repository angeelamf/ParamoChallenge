using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Models;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTest
    {
        [Fact]
        public async Task UserController_CreateUser_Success()
        {
            var userController = new UsersController();

            var result = await userController.CreateUser(new Api.Entities.User(){
                Name = "Test", 
                Email = "test@test.com",
                Address = "test",
                Money = 1,
                Phone = "123123123",
                UserType = Api.Models.Enums.UserType.Normal
            }) as ObjectResult;

            var objResult = result.Value as Result;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.True(objResult.IsSuccess);
        }

        [Fact]
        public async Task UserController_CreateUser_Fail()
        {
            var userController = new UsersController();

            var result = await userController.CreateUser(new Api.Entities.User()
            {
                Name = "Test",
                Email = "testtest.com",
                Address = "test",
                Money = 1,
                Phone = "123123123",
                UserType = Api.Models.Enums.UserType.Normal
            }) as ObjectResult;

            var objResult = result.Value as Result;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.False(objResult.IsSuccess);
        }
        [Fact]
        public async Task UserController_CreateUser_IsDuplicated()
        {
            var userController = new UsersController();

            var result = await userController.CreateUser(new Api.Entities.User()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "test",
                Money = 1,
                Phone = "123123123",
                UserType = Api.Models.Enums.UserType.Normal
            }) as ObjectResult;

            var objResult = result.Value as Result;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.False(objResult.IsSuccess);
        }
    }
}
