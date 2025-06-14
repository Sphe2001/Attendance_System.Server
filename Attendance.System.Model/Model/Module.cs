using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }

        public Course Course { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
