using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class NationalityDetails
    {
        [Key]
        public int nationalityid { get; set; }
        public string nationalityname { get; set; }
    }
}
