using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.PageDetails
{
    public class M_SubPageDetails
    {
        [Key]
        public int SunpageId { get; set; }
        public string SubPageName { get; set; }
        public string SubPageAliasName { get; set; }
        public int PageId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int SequenceNo { get; set; }
        public int PagePath { get; set; }
        public bool IsCustom { get; set; }
    }
}
