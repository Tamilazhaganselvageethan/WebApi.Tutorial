using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class StateDetail
    {
        [Key]
        public int state_id { get; set; }
        public string state_name { get; set; }
    }
}
