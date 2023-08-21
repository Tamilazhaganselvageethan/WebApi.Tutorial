using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class DesignationGradeDetails
    {
        [Key]
        public int designation_grade_id { get; set; }
        public int designation_grade_name { get; set; }
    }
}
