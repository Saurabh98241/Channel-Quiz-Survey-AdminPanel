using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class UserQuizEntity
    {
        public List<QuestionEntity> QuestionEntity { get; set; }
        public List<QuestionOptionMappingEntity> QuestionOptionMappingEntity { get; set; }

        public long UserAnsId { get; set; }
        public long UserId { get; set; }
        public long QuizId { get; set; }
        public long QuestionId { get; set; }
        public string SelectedAns { get; set; }
        public bool IsTrueAns { get; set; }
        public System.DateTime AnswerDate { get; set; }
    }
   
}
