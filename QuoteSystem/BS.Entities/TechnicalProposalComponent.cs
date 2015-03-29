using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities
{
    public class TechnicalProposalComponent
    {
        [Key]
        public long ProposalComponentID { get; set; }

        public int ComponentCount { get; set; }

        public virtual Component Component { get; set; }

        public long TPID { get; set; }

        [ForeignKey("TPID")]
        public virtual TechnicalProposal TechnicalProposal { get; set; }
    }
}
