using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.PageDetails
{
    public class M_SubPageFields
    {
        [Key]
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldAliasName { get; set; }
        public int SubPageId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int SequenceNo { get; set; }
        public string PagePath { get; set; }
        public bool IsCustom { get; set; }
        public bool IsMandatory { get; set; }
        public int DataFieldTypeId { get; set; }
        public bool IsListData { get; set; }
        public bool ShowOnList { get; set; }
    }
}
