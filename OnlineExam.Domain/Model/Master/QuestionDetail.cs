using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Model.Master
{
    public class QuestionDetail
    {
        [Key]
        public int QuestionTypeid { get; set; }
        public string QuetionTypeName { get; set; }
    }
}
