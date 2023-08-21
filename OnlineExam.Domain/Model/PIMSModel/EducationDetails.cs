using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.PIMSModel
{
    public class EducationDetails
    {
        [Key]
        public int degree_id { get; set; }
        public int degree_type_id { get; set; }
        public string degree_name { get; set; }
        public string subject_name { get; set; }
        public string duration { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string grade_percentage { get; set; }
        public int CollegeId { get; set; }
        public int UniversityId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int nationalityid { get; set; }
        public int gradeid { get; set; }
    }
}
