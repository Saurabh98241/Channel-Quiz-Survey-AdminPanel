using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.FactoryClass
{
   public class UserQuestionAnswerFactory : BaseClass
    {
        public void SaveUserAnswer(tblUserQuestionAnswer answer)
        {
            db.tblUserQuestionAnswers.Add(answer);
            db.SaveChanges();
        }
    }
}
