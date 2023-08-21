using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class TemporaryDistrictDetail
    {
        [Key]
        public int district_id { get; set; }
        public string district_name { get; set; }
    }
}
