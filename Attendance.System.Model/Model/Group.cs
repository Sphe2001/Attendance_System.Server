using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        [ForeignKey("ModuleId")]
        public int ModuleId { get; set; }
        public string GroupName { get; set; }

        public Module Module { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
