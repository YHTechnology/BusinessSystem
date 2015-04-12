using QuoteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuoteSystem.Controllers
{

    public class UserResult
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<BS.Entities.User> Results { get; set; }
    }

    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private BusnessSystemDBContext _BusnessSystemDBContext = BusnessSystemDBContext.Create();

        public UserController()
        {

        }

        public UserResult Get(int Page, int PageSize)
        {
            int totalCount = _BusnessSystemDBContext.Users.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / PageSize);
            List<BS.Entities.User> results = _BusnessSystemDBContext.Users.OrderBy(c => c.UserName).Skip(PageSize * Page).Take(PageSize).ToList();

            UserResult lUserResults = new UserResult();
            lUserResults.TotalCount = totalCount;
            lUserResults.TotalPages = totalPages;
            lUserResults.Results = results;
            return lUserResults;
        }

        public IEnumerable<BS.Entities.User> Get()
        {
            return _BusnessSystemDBContext.Users;
        }

        public IEnumerable<BS.Entities.User> Get(string Department)
        {
            return _BusnessSystemDBContext.Users.Where(c => c.Department == Department);
        }

        public BS.Entities.User GetUserByID(string id)
        {
            try
            {
                BS.Entities.User lUser = _BusnessSystemDBContext.Users.Where(c => c.UserName == id).First();
                return lUser;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        
        public void Post([FromBody]BS.Entities.User value)
        {

        }

        public void Put(string id, [FromBody]BS.Entities.User value)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
