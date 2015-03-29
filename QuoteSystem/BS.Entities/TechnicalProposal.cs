using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    public class TechnicalProposal
    {
        [Key]
        public long TechnicalProposalID { get; set; }

        public string TechnicalProposalName { get; set; }

        public string TechnicalProposalVersion { get; set; }

        public virtual ICollection<TechnicalProposalComponent> TechnicalProposalComponents { get; set; }

        // 技术部设计人
        public string TechnologyDesignUser { get; set; }

        // 技术部设计日期
        public Nullable<DateTime> TechnologyDesignDateTime { get; set; }

        // 技术部审核人
        public string TechnologyVerifyUser { get; set; }

        // 技术部审核日期
        public Nullable<DateTime> TechnologyVerifyDateTime { get; set; }
    }
}
