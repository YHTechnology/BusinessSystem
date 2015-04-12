using QuoteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuoteSystem.Controllers
{
    [RoutePrefix("api/BSEvent")]
    public class BSEventController : ApiController
    {
        private BusnessSystemDBContext _BusnessSystemDBContext = BusnessSystemDBContext.Create();

        public BSEventController()
        {

        }

        public IEnumerable<BS.Entities.BSEvent> GetByUser(string UserName)
        {
            return _BusnessSystemDBContext.BSEvents.Where(c => c.EventUser == UserName);
        }

        public void Post([FromBody]BS.Entities.BSEvent value)
        {
            _BusnessSystemDBContext.BSEvents.Add(value);
            _BusnessSystemDBContext.SaveChanges();
        }

        public void Put(long id, [FromBody]BS.Entities.BSEvent value)
        {
            BS.Entities.BSEvent lBSEvent = _BusnessSystemDBContext.BSEvents.Where(c => c.BSEventID == id).FirstOrDefault();
            if (lBSEvent != null)
            {
                lBSEvent = value;
                lBSEvent.BSEventID = id;
                _BusnessSystemDBContext.BSEvents.Attach(lBSEvent);
                _BusnessSystemDBContext.Entry<BS.Entities.BSEvent>(lBSEvent).State = System.Data.Entity.EntityState.Modified;
                _BusnessSystemDBContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            BS.Entities.BSEvent lBSEvent = _BusnessSystemDBContext.BSEvents.Where(c => c.BSEventID == id).FirstOrDefault();
            if (lBSEvent != null)
            {
                _BusnessSystemDBContext.BSEvents.Remove(lBSEvent);
                _BusnessSystemDBContext.SaveChanges();
            }
        }
    }
}
