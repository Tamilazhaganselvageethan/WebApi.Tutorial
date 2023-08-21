using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class NationalityDetail
    {
        [Key]
        public int nationality_id { get; set; }
        public string nationality_name { get; set; }
    }
}
