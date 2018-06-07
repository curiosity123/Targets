using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Targets.Infrastructure.DTO;

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
            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");


            Credentials usr = new Credentials()
            {
                Email = "test@test.pl",
                Password = "pass"
            };

            //create test
            StringContent payload = GetPayload(usr);
            var response = await Client.PostAsync("Account/Register", payload);
            var responseString = await response.Content.ReadAsStringAsync();


            payload = GetPayload(usr);
            response = await Client.PostAsync("Account/Login", payload);
            responseString = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            TokenDTO token = JsonConvert.DeserializeObject<TokenDTO>(responseString);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            var res = await Client.GetAsync("User/Get");

            var respon = await res.Content.ReadAsStringAsync();
            Assert.AreEqual(res.StatusCode, HttpStatusCode.OK);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token+"d");
            res = await Client.GetAsync("User/Get");
            Assert.AreEqual(res.StatusCode, HttpStatusCode.Unauthorized);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Oauth");
            response = await Client.PostAsync("Account/Login", payload);
            responseString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            ////delete test
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            var request = new HttpRequestMessage(HttpMethod.Delete, "Account/Delete");
            //request.Content = payload;
            var deleteResponse = await Client.SendAsync(request);
            Assert.AreEqual(deleteResponse.StatusCode, HttpStatusCode.OK);
        }


    }
}
