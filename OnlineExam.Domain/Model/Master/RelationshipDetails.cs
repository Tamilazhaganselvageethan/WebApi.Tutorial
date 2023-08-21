using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class RelationshipDetails
    {
        [Key]
        public int relationshipid { get; set; }
        public string relationshipname { get; set; }
    }
}
