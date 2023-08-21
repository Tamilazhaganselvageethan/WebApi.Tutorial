using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.PIMSModel
{
    public class PersonalDetails
    {
        [Key]
        public int personal_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string dob { get; set; }
        public int BGId { get; set; }
        public int genderId { get; set; }
        public int religionId { get; set; }
        public int nationalityId { get; set; }
        public DateTime Created_on { get; set; }
        public string Created_By { get; set; }
        public DateTime Modified_On { get; set; }
        public string Modified_By { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
