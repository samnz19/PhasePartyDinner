using DinnerPartyRoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DinnerPartyRoa.Controllers
{
    public class SubmmitController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: api/Submmit
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Submmit/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Submmit
        //public void Post(NewOrder data)
        //{
        //    if((db.GitHubUsers.Where(u=>u.Name.Equals(data.Name)).Count() > 0)
        //    {

        //    }
        //    GitHubUser user = new GitHubUser();
            
        //    user.Name = data.Name; 
           
        //}

        // PUT: api/Submmit/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Submmit/5
        public void Delete(int id)
        {
        }
    }
}
