using QuoteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuoteSystem.Controllers
{
    public class ClientResult
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<BS.Entities.Client> Results { get; set; }
    }

    [RoutePrefix("api/Client")]
    public class ClientController : ApiController
    {
        private BusnessSystemDBContext _BusnessSystemDBContext = BusnessSystemDBContext.Create();

        public ClientController()
        {

        }

        public ClientResult Get(int Page = 0, int PageSize = 10)
        {
            int totalCount = _BusnessSystemDBContext.Users.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / PageSize);
            List<BS.Entities.Client> results = _BusnessSystemDBContext.Client.OrderBy(c => c.ClientName).Skip(PageSize * Page).Take(PageSize).ToList();

            ClientResult lClientResultResults = new ClientResult();
            lClientResultResults.TotalCount = totalCount;
            lClientResultResults.TotalPages = totalPages;
            lClientResultResults.Results = results;
            return lClientResultResults;
        }

        public IEnumerable<BS.Entities.Client> Get()
        {
            return _BusnessSystemDBContext.Client;
        }

        public BS.Entities.Client Get(string id)
        {
            try
            {
                BS.Entities.Client lClient = _BusnessSystemDBContext.Client.Where(c => c.ClientName == id).First();
                return lClient;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public void Post([FromBody]BS.Entities.Client value)
        {

        }

        public void Put(long id, [FromBody]BS.Entities.Client value)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
