using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Domain.Model.AccountDetailModel
{
    public class AccountDetails
    {
        [Key]
        public int account_id { get; set; }
        public string account_holder_name { get; set; }
        public string account_number { get; set; }
        public string bank_register_number { get; set; }
        public int bank_id { get; set; }
        public int branch_id { get; set; }
        public int ifsc_code_id { get; set; }
        public int account_type_id { get; set; }
        public List<test> test { get;set; }
    }

    public class test
    {
        [Key]
        public int data { get; set; }
        public string name { get; set; }
    }

}
