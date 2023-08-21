using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class PermanentCountryDetail
    {
        [Key]
        public int countryid { get; set; }
        public string countryname { get; set; }
    }
}
