using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class ExperienceRoleDetails
    {
        [Key]
        public int roleid { get; set; }
        public string rolename { get; set; }
    }
}
