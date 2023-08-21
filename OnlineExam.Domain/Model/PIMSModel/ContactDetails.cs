using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.PIMSModel
{
    public class ContactDetails
    {
        [Key]
        public int contact_id { get; set; }
        public string contact_no1 { get; set; }
        public string contact_no2 { get; set; }
        public string contact_no3 { get; set; }
        public string contact_tele1 { get; set; }
        public string contact_tele2 { get; set; }
        public string official_mail_id { get; set; }
        public string personal_email_id { get; set; }
        public string website { get; set; }
    }
}
