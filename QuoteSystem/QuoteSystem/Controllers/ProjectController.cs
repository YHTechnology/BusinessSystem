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
            int totalCount = _BusnessSystemDBContext.Projects.Where(c => c.TechnologyUser == aUserName).Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / PageSize);

            List<BS.Entities.Project> results = _BusnessSystemDBContext.Projects.Where(c => c.TechnologyUser == aUserName)
                .OrderBy(c => c.BusinessCreateDateTime).Skip(PageSize * Page).Take(PageSize).ToList();

            ProjectResult lProjectResults = new ProjectResult();
            lProjectResults.TotalCount = totalCount;
            lProjectResults.TotalPages = totalPages;
            lProjectResults.Results = results;
            return lProjectResults;
        }

        public IEnumerable<BS.Entities.Project> Get()
        {
            return _BusnessSystemDBContext.Projects;
        }

        public void Post([FromBody]BS.Entities.Project value)
        {
            _BusnessSystemDBContext.Projects.Add(value);
            _BusnessSystemDBContext.SaveChanges();
        }

        public void Put(long id, [FromBody]BS.Entities.Project value)
        {
            BS.Entities.Project lProject = _BusnessSystemDBContext.Projects.Where(c => c.ProjectID == id).FirstOrDefault();
            if (lProject != null)
            {
                lProject = value;
                lProject.ProjectID = id;
                _BusnessSystemDBContext.Projects.Attach(lProject);
                _BusnessSystemDBContext.Entry<BS.Entities.Project>(lProject).State = System.Data.Entity.EntityState.Modified;
                _BusnessSystemDBContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            BS.Entities.Project lProject = _BusnessSystemDBContext.Projects.Where(c => c.ProjectID == id).FirstOrDefault();
            if (lProject != null)
            {
                _BusnessSystemDBContext.Projects.Remove(lProject);
                _BusnessSystemDBContext.SaveChanges();
            }
        }
    }
}
