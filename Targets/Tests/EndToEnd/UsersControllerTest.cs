using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Tests.EndToEnd
{
    [TestFixture]
    public class UsersControllerTest : ControllerTestsBase
    {

        public UsersControllerTest()
        {

        }
        


        [Test]
        public async Task UserCRUD_test()
        {
            Token usr = new Token()
            {
                Email = "test@test.pl",
                Password = "pass"
            };

            //create test
            StringContent payload = GetPayload(usr);
            var response = await Client.PostAsync("api/Users/RegisterAccount/", payload);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            //read test
            var res = await Client.GetAsync("api/Users/test@test.pl,pass");
            var responseString = await res.Content.ReadAsStringAsync();
            Assert.IsTrue(responseString.Contains("test@test.pl"));
            Assert.AreEqual(res.StatusCode, HttpStatusCode.OK);

            //delete test
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/Users/DeleteAccount/");
            request.Content = payload;
            var deleteResponse = await Client.SendAsync(request);
            Assert.AreEqual(deleteResponse.StatusCode, HttpStatusCode.OK);
        }


    }
}
