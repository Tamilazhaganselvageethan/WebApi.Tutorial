using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class OccupationDetails
    {
        [Key]
        public int occupation_id { get; set; }
        public string occupation_name { get; set; }
    }
}
