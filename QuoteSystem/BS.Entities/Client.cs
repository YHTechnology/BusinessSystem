using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities
{
    public class Client
    {
        public long ClientID { get; set; }

        public string ClientName { get; set; }

        public string CountryDomain { get; set; }

        public string ContactPerson { get; set; }

        public string ContactWay { get; set; }

        public string Duties { get; set; }
    }
}
