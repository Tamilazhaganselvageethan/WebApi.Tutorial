using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class IFSCDetail
    {
        [Key]
        public int ifsc_id { get; set; }
        public string ifsc_code { get; set; }
    }
}
