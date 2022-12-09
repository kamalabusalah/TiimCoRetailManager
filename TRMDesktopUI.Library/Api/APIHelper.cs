using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TRMdesktopUI.Models;
using TRMdesktopUI.Library.Api;
using TRMDesktopUI.Library.Models;
using System.Net.Http.Headers;

namespace TRMdesktopUI.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient;
        private ILoggedInUserModel _LoggedInUser;

        public APIHelper(ILoggedInUserModel loggedInUser) 
        {
            InitialzeClient();
            _LoggedInUser=loggedInUser;
        }
        public HttpClient ApiClient
        {
            get 
            { 
                return _apiClient; 
            }
        }


        private void InitialzeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

        }
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                 new KeyValuePair<string, string>("username", username),
                  new KeyValuePair<string, string>("password", password)
            });
            using (HttpResponseMessage respone = await _apiClient.PostAsync("/Token", data))
            {
                if (respone.IsSuccessStatusCode)
                {
                    var result = await respone.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(respone.ReasonPhrase);
                }

            }
        }
        public async Task GetLoggedInUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();    
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            using (HttpResponseMessage respone = await _apiClient.GetAsync("/api/User"))
            {
                if (respone.IsSuccessStatusCode)
                {
                    var result=await respone.Content.ReadAsAsync<LoggedInUserModel>();
                    _LoggedInUser.Id = result.Id;
                    _LoggedInUser.CreatedDate = result.CreatedDate;
                    _LoggedInUser.EmailAddress = result.EmailAddress;
                    _LoggedInUser.FirstName= result.FirstName;
                    _LoggedInUser.LastName= result.LastName;
                  
                    _LoggedInUser.Token = token;

                }
                else
                {
                    throw new Exception(respone.ReasonPhrase);
                }

            }

        }

        //Task IAPIHelper.GetLoggedInUserInfo(string token)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
