using BusinessLogic.EntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.FactoryClass
{
   public class PlayQuizFactory: BaseClass
    {
        public List<QuestionEntity> GetQuestionsByQuizId(long Id)
        {
            List<QuestionEntity> lstQuestion = new List<QuestionEntity>();

            lstQuestion = db.tblQuestions.Where(x => x.QuizId == Id && x.IsActive == true).Select(x => new QuestionEntity()
            {   QuizId = x.QuizId,
                QuestionId = x.QuestionId,
                Question = x.Question,
                IsMultiple = x.IsMultiple,

            }).ToList();
            return lstQuestion;
        }


        public List<QuestionOptionMappingEntity> GetOption()
        {
            List<QuestionOptionMappingEntity> lstQuestion = new List<QuestionOptionMappingEntity>();

            lstQuestion = db.tblQuestionOptionMappings.Where(x=>x.IsActive == true).Select(x => new QuestionOptionMappingEntity()
            {
                OptionId= x.OptionId,
                QuestionId = x.QuestionId,
                QuestionOptionText = x.QuestionOptionText,
                IsTrue = x.IsTrue,
            }).ToList();
            return lstQuestion;
        }
    }
}
