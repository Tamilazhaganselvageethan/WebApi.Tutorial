using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class BloodGroupDetails
    {
        [Key]
        public int BG_id { get; set; }
        public string Blood_name { get; set; }
    }
}
