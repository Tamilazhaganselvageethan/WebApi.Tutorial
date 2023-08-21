using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class BranchNameDetails
    {
        [Key]
        public int branch_id { get; set; }
        public string branch_name { get; set; }
    }
}
