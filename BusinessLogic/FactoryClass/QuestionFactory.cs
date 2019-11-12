using BusinessLogic.EntityClass;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.FactoryClass
{
    public class QuestionFactory :BaseClass
    {
        public List<QuestionEntity> GetQuestion()
        {
            List<QuestionEntity> ListQuestion = new List<QuestionEntity>();
            ListQuestion = (from t in db.tblQuestions
                         join c in db.tblQuizs on t.QuizId equals c.QuizId
                         where t.IsActive == true
                         select new QuestionEntity()
                         {
                             QuestionId = t.QuestionId,
                             Question = t.Question,
                             QuizId = t.QuizId,
                             QuizName = c.QuizName,
                             IsMultiple =t.IsMultiple
                         }).ToList();

            return ListQuestion;
        }
        public void SaveQuestion(tblQuestion Question)
        {
            if (Question.QuestionId == 0)
            {
                db.tblQuestions.Add(Question);
            }
            else
            {
                db.Entry(Question).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public QuestionEntity GetQuestionById(long Id)
        {
            QuestionEntity Question = new QuestionEntity();
            Question = db.tblQuestions.Where(x => x.QuestionId == Id).Select(x => new QuestionEntity()
            {
                QuizId = x.QuizId,
                Question = x.Question,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                IsActive = x.IsActive
            }).FirstOrDefault();
            return Question;
        }
    }
}
