﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class UniversityDetail
    {
        [Key]
        public int university_id { get; set; }
        public string university_name { get; set; }
    }
}
