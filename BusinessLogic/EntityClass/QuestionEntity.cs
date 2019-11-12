using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
    public class QuestionEntity:BaseEntity
    {
        public long QuestionId { get; set; }
        [DisplayName("Quiz")]
        [Required(ErrorMessage = "Please select Channel")]
        public long QuizId { get; set; }
        [DisplayName("Quiz Name")]
        public string QuizName { get; set; }
        [DisplayName("Question")]
        [Required(ErrorMessage = "Please enter Question")]
        [MaxLength(50)]
        public string Question { get; set; }
        public bool IsMultiple { get; set; }

        public QuestionOptionMappingEntity QuestionOptionMappingEntity { get; set; }

    }
}
