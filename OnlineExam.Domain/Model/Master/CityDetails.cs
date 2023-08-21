using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class CityDetails
    {
        [Key]
        public int cityid { get; set; }
        public string cityname { get; set; }
    }
}
