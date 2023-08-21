using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class PermanentDistrictDetail
    {
        [Key]
        public int districtid { get; set; }
        public string districtname { get; set; }
    }
}
