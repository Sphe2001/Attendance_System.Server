using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class FaceData
    {
        [Key]
        public int FaceDataId { get; set; }
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public List<float> FaceEmbedding { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public Student Student { get; set; }
    }
}
