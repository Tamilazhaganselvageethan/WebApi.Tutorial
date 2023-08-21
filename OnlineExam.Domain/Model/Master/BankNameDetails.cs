using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class BankNameDetails
    {
        [Key]
        public int bank_id { get; set; }
        public string bank_name { get; set; }
    }
}
