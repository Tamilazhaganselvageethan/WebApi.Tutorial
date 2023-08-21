using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class ReligionNameDetail
    {
        [Key]
        public int Religionid { get; set; }
        public string Religion_name { get; set; }
    }
}
