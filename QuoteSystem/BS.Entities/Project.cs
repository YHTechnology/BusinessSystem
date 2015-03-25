
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BS.Entities
{
    public enum ProjectStatus
    {

    }

    public class Project
    {
        // 项目编号
        [Key]
        public long ProjectID { get; set; }

        // 项目名称
        public string ProjectName { get; set; }

        // 原始文件
        public virtual ICollection<OriginalFile> OriginalFiles { get; set; }

        // 描述
        public string Describe { get; set; }

        // 技术部描述
        public string TechnologyDescribe { get; set; }

        // 商务部创建人
        public string BusinessCreateUser { get; set; }

        // 商务部创建日期
        public DateTime BusinessCreateDateTime { get; set; }

        // 技术部设计人
        public string TechnologyDesignUser { get; set; }
        
        // 技术部设计日期
        public DateTime TechnologyDesignDateTime { get; set; }

        // 技术部审核人
        public string TechnologyVerifyUser { get; set; }
    
        // 技术部审核日期
        public DateTime TechnologyVerifyDateTime { get; set; }

        // 状态
        public ProjectStatus ProjectStatus { get; set; }
    }
}
