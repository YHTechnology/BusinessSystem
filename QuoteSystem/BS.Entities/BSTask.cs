using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities
{
    public enum BSTaskType
    {
        Design,
        Verify,
        Quoted
    }

    public enum BSTaskStatus
    {
        Created,
        Progressing,
        Finished
    }

    public class BSTask
    {
        // 任务编号
        [Key]
        public long BSTaskID { get; set; }

        // 任务类型
        public BSTaskType TaskType { get; set; }

        // 任务用户编号
        public string TaskUser { get; set; }

        // 任务用户名
        public string TaskCUser { get; set; }

        // 创建任务用户编号
        public string CreateTaskUser { get; set; }

        // 创建任务用户名
        public string CreateTaskCUser { get; set; }

        // 任务状态
        public BSTaskStatus TaskStatus { get; set; }

        // 创建时间
        public DateTime CreateDateTime { get; set; }

        // 完成时间
        public DateTime FinishDateTime { get; set; }

        // 任务名称
        public string TaskName { get; set; }

        // 任务描述
        public string TaskDescribe { get; set; }

        // 任务内容
        public string TaskContext { get; set; }
    }
}
