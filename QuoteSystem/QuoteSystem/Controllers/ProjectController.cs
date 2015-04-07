using QuoteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuoteSystem.Controllers
{
    public class ProjectResult
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<BS.Entities.Project> Results { get; set; }
    }

    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        private BusnessSystemDBContext _BusnessSystemDBContext = BusnessSystemDBContext.Create();

        public ProjectController()
        {

        }

        public ProjectResult Get(int Page, int PageSize, string aUserName)
        {
            return null;
        }

        public IEnumerable<BS.Entities.Project> Get()
        {
            return _BusnessSystemDBContext.Projects;
        }

        public void Post([FromBody]BS.Entities.Project value)
        {

        }

        public void Put(long id, [FromBody]BS.Entities.Project value)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
