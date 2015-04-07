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

        public ClientResult Get(int Page, int PageSize)
        {
            int totalCount = _BusnessSystemDBContext.Clients.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / PageSize);
            List<BS.Entities.Client> results = _BusnessSystemDBContext.Clients.OrderBy(c => c.ClientName).Skip(PageSize * Page).Take(PageSize).ToList();

            ClientResult lClientResultResults = new ClientResult();
            lClientResultResults.TotalCount = totalCount;
            lClientResultResults.TotalPages = totalPages;
            lClientResultResults.Results = results;
            return lClientResultResults;
        }

        public IEnumerable<BS.Entities.Client> Get()
        {
            return _BusnessSystemDBContext.Clients;
        }

        public BS.Entities.Client Get(string id)
        {
            BS.Entities.Client lClient = _BusnessSystemDBContext.Clients.Where(c => c.ClientName == id).FirstOrDefault();
            return lClient;
        }

        public void Post([FromBody]BS.Entities.Client value)
        {
            _BusnessSystemDBContext.Clients.Add(value);
            _BusnessSystemDBContext.SaveChanges();
        }

        public void Put(long id, [FromBody]BS.Entities.Client value)
        {
            BS.Entities.Client lClient = _BusnessSystemDBContext.Clients.Where(c => c.ClientID == id).FirstOrDefault();
            if (lClient != null)
            {
                lClient = value;
                lClient.ClientID = id;
                _BusnessSystemDBContext.Clients.Attach(lClient);
                _BusnessSystemDBContext.Entry<BS.Entities.Client>(lClient).State = System.Data.Entity.EntityState.Modified;
                _BusnessSystemDBContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            BS.Entities.Client lClient = _BusnessSystemDBContext.Clients.Where(c => c.ClientID == id).FirstOrDefault();
            if (lClient != null)
            {
                _BusnessSystemDBContext.Clients.Remove(lClient);
                _BusnessSystemDBContext.SaveChanges();
            }
        }
    }
}
