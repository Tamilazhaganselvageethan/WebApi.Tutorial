using OnlineExam.Domain.Model.AccountDetailModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.PIMSModel
{
    public class AddressDetails
    {
        [Key]
        public int address_id { get; set; }
        public string permanent_line1 { get; set; }
        public string permanent_line2 { get; set; }
        public string permanent_line3 { get; set; }
        public string permanent_land_mark { get; set; }
        public int cityid { get; set; }
        public int districtid { get; set; }
        public int countryid { get; set; }
        public int pincodeid { get; set; }
        public string temp_line1 { get; set; }
        public string temp_line2 { get; set; }
        public string temp_line3 { get; set; }
        public string temp_land_mark { get; set; }
        public int city_id { get; set; }
        public int district_id { get; set; }
        public int country_id { get; set; }
        public int pincode_id { get; set; }
    }

    public class cus
    {
        [Key]
        public AddressDetails addresses { get; set;}
        public AccountDetails acc { get; set; }

    }



}
