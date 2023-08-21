using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class PermanentPincodeDetail
    {
        [Key]
        public int pincodeid { get; set; }
        public string pincodename { get; set; }
    }
}
