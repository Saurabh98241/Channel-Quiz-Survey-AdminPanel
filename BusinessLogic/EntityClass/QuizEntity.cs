using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class QuizEntity:BaseEntity
    {
        public long QuizId { get; set; }
        [DisplayName("Quiz Name")]
        [MaxLength(500)]
        [Required(ErrorMessage = "Please enter quiz name")]
        public string QuizName { get; set; }
    }
}
