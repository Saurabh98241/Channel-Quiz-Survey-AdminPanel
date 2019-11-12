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
    public class SurveyFactory : BaseClass
    {
        public List<SurveyEntity> GetSurvey()
        {
            List<SurveyEntity> ListSurvey = new List<SurveyEntity>();
            //ListSurvey = db.tblSurveys.OrderByDescending(x => x.SurveyId).Where(x => x.IsActive == true).Select(x => new SurveyEntity()
            //{
            //    SurveyId = x.SurveyId,
            //    SurveyName = x.SurveyName,
            //    AnsTypeId = x.AnsTypeId,
            //    SurveyDescription= x.SurveyDescription,
            //    CompletionText = x.CompletionText,
            //    IsNeverExpire = x.IsNeverExpire,
            //    ExpiryDate = x.ExpiryDate

            //}).ToList();

            ListSurvey = (from s in db.tblSurveys
                          join a in db.tblSurveyAnswerTypes on s.AnsTypeId equals a.AnsTypeId where s.IsActive==true
                          select new SurveyEntity()
                          {
                              SurveyId = s.SurveyId,
                              SurveyName = s.SurveyName,
                              AnsTypeId = s.AnsTypeId,
                              AnswerType = a.AnswerType,
                              SurveyDescription = s.SurveyDescription,
                              CompletionText = s.CompletionText,
                              IsNeverExpire = s.IsNeverExpire,
                              ExpiryDate = s.ExpiryDate
                          }).ToList();
            return ListSurvey;
        }
        public void SaveSurvey(tblSurvey Survey)
        {
            if (Survey.SurveyId == 0)
            {
                db.tblSurveys.Add(Survey);
            }
            else
            {
                db.Entry(Survey).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public SurveyEntity GetSurveyById(long Id)
        {
            
            SurveyEntity Survey = new SurveyEntity();
            //Survey = db.tblSurveys.Where(x => x.SurveyId == Id).Select(x => new SurveyEntity()
            //{

            //    SurveyId = x.SurveyId,
            //    SurveyName = x.SurveyName,
            //    AnsTypeId = x.AnsTypeId,
            //    SurveyDescription = x.SurveyDescription,
            //    CompletionText = x.CompletionText,
            //    IsNeverExpire = x.IsNeverExpire,
            //    ExpiryDate = x.ExpiryDate,
            //    CreatedBy = x.CreatedBy,
            //    CreatedDate = x.CreatedDate,
            //    UpdatedBy = x.UpdatedBy,
            //    UpdatedDate = x.UpdatedDate,
            //    IsActive = x.IsActive
            //}).FirstOrDefault();

            Survey = (from s in db.tblSurveys
                    join a in db.tblSurveyAnswerTypes on s.AnsTypeId equals a.AnsTypeId
                    where s.SurveyId == Id
                    select new SurveyEntity()
                    {
                        SurveyId = s.SurveyId,
                        SurveyName = s.SurveyName,
                        AnsTypeId = s.AnsTypeId,
                        AnswerType = a.AnswerType,
                        SurveyDescription = s.SurveyDescription,
                        CompletionText = s.CompletionText,
                        IsNeverExpire = s.IsNeverExpire,
                        ExpiryDate = s.ExpiryDate,
                        CreatedBy = s.CreatedBy,
                        CreatedDate = s.CreatedDate,    
                        UpdatedBy = s.UpdatedBy,
                        UpdatedDate = s.UpdatedDate,
                        IsActive = s.IsActive
                    }).FirstOrDefault();


            return Survey;


        }

        public List<SurveyAnswerTypeEntity> GetSurveyAnswerType()
        {
            List<SurveyAnswerTypeEntity> ListSurveyAnswerType = new List<SurveyAnswerTypeEntity>();
            ListSurveyAnswerType = db.tblSurveyAnswerTypes.Select(x => new SurveyAnswerTypeEntity()
            {
                AnsTypeId = x.AnsTypeId,
                AnswerType = x.AnswerType

            }).ToList();
            return ListSurveyAnswerType;
        }


    }
}
