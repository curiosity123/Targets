using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Targets.Infrastructure.DTO;

namespace Targets.Tests.EndToEnd
{
    [TestFixture]
    public class UsersControllerTest : ControllerTestsBase
    {

        [Test]
        public async Task ShoudRegisterAccount()
        {
            RegisterUserDto usr = new RegisterUserDto()
            {
                Email = "test@test.pl",
                Password = "pass"
            };

            var payload = GetPayload(usr);
            var response = await Client.PostAsync("api/Users/RegisterAccount/", payload);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            var res = await Client.GetAsync("api/Users/test@test.pl, pass");
            var responseString = await res.Content.ReadAsStringAsync();
            Assert.IsTrue(responseString.Contains("test@test.pl"));
            Assert.AreEqual(res.StatusCode, HttpStatusCode.OK);
        }
    }
}
