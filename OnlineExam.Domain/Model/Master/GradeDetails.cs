using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class GradeDetails
    {
        [Key]
        public int grade_id { get; set; }
        public string grade_name { get; set; }
    }
}
