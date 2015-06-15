using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using DinnerPartyRoa.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DinnerPartyRoa.Services
{
    public class GitHubApiService
    {
        public List<GitHubUser> Users { get; set; }

        public List<GitHubUser> GetGitHubUsers()
        {
            TalkToGithub();
            return Users;
        }


        private async void TalkToGithub()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.GetAsync("orgs/enspiral-dev-academy/members");
                if (response.IsSuccessStatusCode)
                {
                   //add to list
                    string json = response.Content.ReadAsStringAsync().Result;
                    AddToList(json);


                }
            }
        }

        // private method take response and add to list
        private List<GitHubUser> AddToList(string json)
        {
            var individualUser = new List<GitHubUser>();
            //ask dan about dynamic data and whether its the best option to take
            dynamic data = JObject.Parse(json);
           // JsonConvert.DeserializeObject<GitHubUser>(json);

            var name = data.login.ToString();
            individualUser.Add(new GitHubUser(){Name = name});

            return individualUser;
        } 
        
    }
}
            
      