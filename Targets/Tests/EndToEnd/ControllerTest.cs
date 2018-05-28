using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;
using Newtonsoft.Json;
using Targets.Infrastructure.Services;

namespace Targets.Tests.EndToEnd
{
    [TestFixture]
    public class ControllerTest : ControllerTestsBase
    {

        public ControllerTest()
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


        [Test]
        public async Task ProjectCRUD_test()
        {
            Token usr = new Token()
            {
                Email = "test@test.pl",
                Password = "pass"
            };

            //register user
            StringContent payload = GetPayload(usr);
            var response = await Client.PostAsync("api/Users/RegisterAccount/", payload);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);


            var res = await Client.GetAsync("api/Users/test@test.pl,pass");
            var responseString = await res.Content.ReadAsStringAsync();
            Assert.AreEqual(res.StatusCode, HttpStatusCode.OK);

            payload = GetPayload(new NewProjectDTO() { token = usr, Title = "prj", Description = "dsc" });
            response = await Client.PostAsync("api/Projects/Add/", payload);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);


            res = await Client.GetAsync("api/Users/test@test.pl,pass");
            responseString = await res.Content.ReadAsStringAsync();
            var u = JsonConvert.DeserializeObject<User>(responseString);
            Assert.IsTrue(u.Projects.Count() == 1);
        }

        [Test]
        public async Task StepCRUD_test()
        {
            Token usr = new Token()
            {
                Email = "test@test.pl",
                Password = "pass"
            };

            //register user
            StringContent payload = GetPayload(usr);
            var response = await Client.PostAsync("api/Users/RegisterAccount/", payload);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);


            var res = await Client.GetAsync("api/Users/test@test.pl,pass");
            var responseString = await res.Content.ReadAsStringAsync();
            Assert.AreEqual(res.StatusCode, HttpStatusCode.OK);

            payload = GetPayload(new NewProjectDTO() { token = usr, Title = "prj", Description = "dsc" });
            response = await Client.PostAsync("api/Projects/Add/", payload);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);


            res = await Client.GetAsync("api/Users/test@test.pl,pass");
            responseString = await res.Content.ReadAsStringAsync();
            User u = JsonConvert.DeserializeObject<User>(responseString);
            Assert.IsTrue(u.Projects.Count > 0);



            payload = GetPayload(new NewStepDto() { token = usr, ProjectId = u.Projects[0].Id, StepTitle = "stp", StepDescription = "sdsc" });
            response = await Client.PostAsync("api/Steps/Add/", payload);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);


            res = await Client.GetAsync("api/Users/test@test.pl,pass");
            responseString = await res.Content.ReadAsStringAsync();
            u = JsonConvert.DeserializeObject<User>(responseString);
            Assert.IsTrue(u.Projects[0].Steps.Count() > 0);
        }

    }
}
