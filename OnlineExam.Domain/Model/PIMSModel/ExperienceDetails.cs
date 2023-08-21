using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.PIMSModel
{
    public class ExperienceDetails
    {
        [Key]
        public int experience_id { get; set; }
        public int companyid { get; }
        public int companytypeid { get; }
        public string exp_duration { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string company_website { get; set; }
        public string contact_no { get; set; }
        public int roleid { get; set; }
        public int cityid { get; set; }
        public int designation_grade_id { get; set; }
        public int demail_id { get; }
    }
}
