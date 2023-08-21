using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class TemporaryPincodeDetail
    {
        [Key]
        public int pincode_id { get; set; }
        public string pincode_name { get; set; }
    }
}
