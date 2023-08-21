using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class LeaveDetails
    {
        [Key]
        public int LeaveTypeid { get; set; }
        public string LeaveTypeName { get; set; }
    }
}
