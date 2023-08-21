using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Domain.Model.PageDetails
{
    public class M_PageDetails
    {
        [Key]

        public int pageid { get; set; }
        public string PageName { get; set; }
        public string PageAliasName { get; set; }
        public int ParentId { get; set; }
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
    }
}
