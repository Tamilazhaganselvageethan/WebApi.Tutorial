using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class GenderDetails
    {
        [Key]
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
}
