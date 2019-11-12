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
   public class QuizFactory:BaseClass
    {
        public List<QuizEntity> GetQuiz()
        {
            List<QuizEntity> ListQuiz = new List<QuizEntity>();
            ListQuiz = db.tblQuizs.OrderByDescending(x => x.QuizId).Where(x => x.IsActive == true).Select(x => new QuizEntity()
            {
                QuizId = x.QuizId,
                QuizName = x.QuizName

            }).ToList();
            return ListQuiz;
        }
        public void SaveQuiz(tblQuiz Quiz)
        {
            if (Quiz.QuizId == 0)
            {
                db.tblQuizs.Add(Quiz);
            }
            else
            {
                db.Entry(Quiz).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public QuizEntity GetQuizById(long Id)
        {
            QuizEntity Quiz = new QuizEntity();
            Quiz = db.tblQuizs.Where(x => x.QuizId == Id).Select(x => new QuizEntity()
            {
                QuizName = x.QuizName,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                IsActive = x.IsActive
            }).FirstOrDefault();
            return Quiz;
        }
    }
}
