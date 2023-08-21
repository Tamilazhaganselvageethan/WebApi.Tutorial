using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class CollegeDetails
    {
        [Key]
        public int college_id { get; set; }
        public string college_name { get; set; }
    }
}
