using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class TemporaryCountryDetail
    {
        [Key]
        public int Country_id { get; set; }
        public string Country_name { get; set; }
    }
}
