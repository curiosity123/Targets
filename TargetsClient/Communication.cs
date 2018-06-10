using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TargetsClient
{
    public sealed class Communication
    {
        private static readonly object locker = new object();
        private static Communication instance = null;
        private string ConnectionPath = "http://localhost:55500/";
        private HttpClient Client;
        public TokenDTO Token;

        private Communication()
        {
            Client = new HttpClient();
            Client.Timeout = new TimeSpan(0, 0, 100);
        }

        public static Communication Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Communication();
                    }
                    return instance;
                }
            }
        }

        private static StringContent Payload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }


        #region API commands

        public async Task<HttpStatusCode> LoginAsync(string Login, string Password)
        {
            Credentials usr = new Credentials()
            {
                Email = Login,
                Password = Password
            };

            var payload = Payload(usr);
            var response = await Client.PostAsync(ConnectionPath + "Account/Login", payload);
            var responseString = await response.Content.ReadAsStringAsync();

            Token = JsonConvert.DeserializeObject<TokenDTO>(responseString);
            return await Task.FromResult(response.StatusCode);
        }

        public async Task<HttpStatusCode> RegisterAsync(string Login, string Password)
        {
            Credentials usr = new Credentials()
            {
                Email = Login,
                Password = Password
            };

            //create test
            StringContent payload = Payload(usr);
            var response = await Client.PostAsync(ConnectionPath + "Account/Register", payload);
            var responseString = await response.Content.ReadAsStringAsync();
            Token = JsonConvert.DeserializeObject<TokenDTO>(responseString);
            return await Task.FromResult(response.StatusCode);
        }

        public async Task<HttpStatusCode> RemoveUserAsync()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);
            var request = new HttpRequestMessage(HttpMethod.Delete, ConnectionPath + "Account/Delete");
            var deleteResponse = await Client.SendAsync(request);
            return await Task.FromResult(deleteResponse.StatusCode);
        }


        public async Task<User> GetUser()
        {
            User u = null;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);

            var res = await Client.GetAsync(ConnectionPath + "User/Get");

            var respon = await res.Content.ReadAsStringAsync();
            var Error = res.StatusCode.ToString();
            if (res.StatusCode == HttpStatusCode.OK)
                u = JsonConvert.DeserializeObject<User>(respon);
            return await Task.FromResult(u);
        }


        public async Task<List<Project>> GetProjects()
        {
            List<Project> u = null;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);

            var res = await Client.GetAsync(ConnectionPath + "Projects/GetProjects");

            var respon = await res.Content.ReadAsStringAsync();
            var Error = res.StatusCode.ToString();
            if (res.StatusCode == HttpStatusCode.OK)
                u = JsonConvert.DeserializeObject<List<Project>>(respon);
            return await Task.FromResult(u);
        }


        public async Task<HttpStatusCode> AddNewProject(string Title, string Description)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);
            NewProjectDTO edit = new NewProjectDTO() { Title = Title, Description = Description };
            StringContent payload = Payload(edit);
            var response = await Client.PostAsync(ConnectionPath + "Projects/AddProject", payload);
            return await Task.FromResult(response.StatusCode);
        }

        public async Task<HttpStatusCode> AddNewStep(Guid projectId, string Title, string Description)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);
            NewStepDTO edit = new NewStepDTO() { ProjectId= projectId,  StepTitle = Title, StepDescription = Description };
            StringContent payload = Payload(edit);
            var response = await Client.PostAsync(ConnectionPath + "Projects/AddStep", payload);
            return await Task.FromResult(response.StatusCode);
        }

        public async Task<HttpStatusCode> RemoveProject(RemProjectDTO prj)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);
            RemProjectDTO edit = new RemProjectDTO() { ProjectId = prj.ProjectId };
            StringContent payload = Payload(edit);
            var request = new HttpRequestMessage(HttpMethod.Delete, ConnectionPath + "Projects/DeleteProject");
            request.Content = payload;
            var deleteResponse = await Client.SendAsync(request);
            return await Task.FromResult(deleteResponse.StatusCode);
        }

        public async Task<HttpStatusCode> RemoveStep(RemStepDTO prj)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);
            RemStepDTO edit = new RemStepDTO() { ProjectId = prj.ProjectId, StepId = prj.StepId };
            StringContent payload = Payload(edit);
            var request = new HttpRequestMessage(HttpMethod.Delete, ConnectionPath + "Projects/DeleteStep");
            request.Content = payload;
            var deleteResponse = await Client.SendAsync(request);
            return await Task.FromResult(deleteResponse.StatusCode);
        }

        public async Task<HttpStatusCode> EditProject(EditProjectDTO prj)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);
            EditProjectDTO edit = new EditProjectDTO() { ProjectId = prj.ProjectId, UpdatedTitle = prj.UpdatedTitle, UpdatedDescription = prj.UpdatedDescription };
            StringContent payload = Payload(edit);
            var response = await Client.PostAsync(ConnectionPath + "Projects/EditProject", payload);
            return await Task.FromResult(response.StatusCode);
        }

        public async Task<HttpStatusCode> EditStep(EditStepDTO prj)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);
            EditStepDTO edit = new EditStepDTO() { ProjectId = prj.ProjectId, StepId = prj.StepId, UpdatedStepTitle = prj.UpdatedStepTitle, UpdatedStepDescription = prj.UpdatedStepDescription };
            StringContent payload = Payload(edit);
            var response = await Client.PostAsync(ConnectionPath + "Projects/EditStep", payload);
            return await Task.FromResult(response.StatusCode);
        }

        public async Task<HttpStatusCode> SetStep(SetStateStepDTO prj)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Token);
            SetStateStepDTO edit = new SetStateStepDTO() {   ProjectId = prj.ProjectId, StepId = prj.StepId, IsDone = prj.IsDone };
            StringContent payload = Payload(edit);
            var response = await Client.PostAsync(ConnectionPath + "Projects/SetStateStep", payload);
            return await Task.FromResult(response.StatusCode);
        }

        #endregion

    }



}
