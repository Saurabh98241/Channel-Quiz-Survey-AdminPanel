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
    public class QuestionOptionMappingFactory : BaseClass
    {
        public void SaveOption(tblQuestionOptionMapping opt)
        {
            if (opt.OptionId == 0)
            {
                db.tblQuestionOptionMappings.Add(opt);
            }
            else
            {
                db.Entry(opt).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        public bool IsTrueAnswer(string OptionText, long QuestionID)
        {
            QuestionOptionMappingEntity ansMapping = new QuestionOptionMappingEntity();
            if (OptionText != null)
            {
                ansMapping = db.tblQuestionOptionMappings.Where(x => x.QuestionOptionText.Trim() == OptionText.Trim() && x.IsActive == true).Select(x => new QuestionOptionMappingEntity
                {
                    IsTrue = x.IsTrue
                }).SingleOrDefault();
                if (ansMapping.IsTrue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

           
        }
    }
}
