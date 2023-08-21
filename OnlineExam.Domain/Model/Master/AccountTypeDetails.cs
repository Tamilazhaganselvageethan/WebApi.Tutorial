using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class AccountTypeDetails
    {
        [Key]
        public int AccountTypeid { get; set; }
        public string AccoutTYpeName { get; set; }
    }
}
