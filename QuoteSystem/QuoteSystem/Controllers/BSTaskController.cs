using QuoteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuoteSystem.Controllers
{
    [RoutePrefix("api/BSTask")]
    public class BSTaskController : ApiController
    {
        private BusnessSystemDBContext _BusnessSystemDBContext = BusnessSystemDBContext.Create();

        public BSTaskController()
        {

        }

        public IEnumerable<BS.Entities.BSTask> GetByUser(string UserName, BS.Entities.BSTaskStatus TaskStatus)
        {
            return _BusnessSystemDBContext.BSTasks.Where(c => c.TaskUser == UserName);
        }

        public IEnumerable<BS.Entities.BSTask> GetByCreateUser(string CreateUserName, BS.Entities.BSTaskStatus TaskStatus)
        {
            return _BusnessSystemDBContext.BSTasks.Where(c => c.CreateTaskUser == CreateUserName);
        }


        public void Post([FromBody]BS.Entities.BSTask value)
        {
            _BusnessSystemDBContext.BSTasks.Add(value);
            _BusnessSystemDBContext.SaveChanges();
        }

        public void Put(long id, [FromBody]BS.Entities.BSTask value)
        {
            BS.Entities.BSTask lBSTask = _BusnessSystemDBContext.BSTasks
                                            .Where(c => c.BSTaskID == id)
                                            .FirstOrDefault();
            if (lBSTask != null)
            {
                lBSTask = value;
                lBSTask.BSTaskID = id;
                _BusnessSystemDBContext.Entry<BS.Entities.BSTask>(lBSTask).State = System.Data.Entity.EntityState.Modified;
                _BusnessSystemDBContext.BSTasks.Attach(lBSTask);
                _BusnessSystemDBContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            BS.Entities.BSTask lBSTask = _BusnessSystemDBContext.BSTasks
                                            .Where(c => c.BSTaskID == id)
                                            .FirstOrDefault();
            if (lBSTask != null)
            {
                _BusnessSystemDBContext.BSTasks.Remove(lBSTask);
                _BusnessSystemDBContext.SaveChanges();
            }
        }
    }
}
