using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities
{
    public class BSEvent
    {
        [Key]
        public long BSEventID { get; set; }

        public long TaskID { get; set; }

        public bool IsShow { get; set; }

        public string EventUser { get; set; }


    }
}
