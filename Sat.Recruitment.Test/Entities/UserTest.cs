using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Entities;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test.Entities
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserTest
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { new User { Name = "", Address = "", Email = "", Money = 200, Phone = "123123123", UserType = Api.Models.Enums.UserType.Normal } };
            yield return new object[] { new User { Name = "", Address = "", Email = "", Money = 200, Phone = "123123123", UserType = Api.Models.Enums.UserType.SuperUser } };
            yield return new object[] { new User { Name = "", Address = "", Email = "", Money = 200, Phone = "123123123", UserType = Api.Models.Enums.UserType.Premium } };
        }
        [Fact]
        public void User_ValidateErrores_String()
        {
            User user = new User();
            string errors = user.ValidateErrors();

            Assert.NotNull(errors);
        }

        [Theory()]
        [MemberData(nameof(TestData))]
        public void User_CalculateMoney_String(User user)
        {
            user.CalculateMoney();

            switch (user.UserType)
            {
                case UserType.Normal:
                    Assert.Equal(224, user.Money);
                    break;
                case UserType.SuperUser:
                    Assert.Equal(240, user.Money);
                    break;
                case UserType.Premium:
                    Assert.Equal(600, user.Money);
                    break;
            }
        }
    }
}
