using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.PIMSModel
{
    public class FamilyDetails
    {
        [Key]
        public int familymemberid { get; set; }
        public string familymembername { get; set; }
        public string family_member_dob { get; set; }
        public int relationshipid { get; set; }
        public int occupationid { get; set; }
        public string member_contact_number { get; set; }
    }
}
