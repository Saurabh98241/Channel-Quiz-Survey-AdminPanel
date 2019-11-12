using BusinessLogic.EntityClass;
using BusinessLogic.FactoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerveAdminPanel.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        private void GetSurveyAnswerType()
        {
            SurveyFactory UF = new SurveyFactory();
            List<SurveyAnswerTypeEntity> SurveyAnswerTypeList = UF.GetSurveyAnswerType().ToList();
            ViewBag.SurveyAnswerTypes = new SelectList(SurveyAnswerTypeList, "AnsTypeId", "AnswerType");
        }
        public ActionResult Survey()
        {
            SurveyFactory SF = new SurveyFactory();
            List<SurveyEntity> SurveyList = SF.GetSurvey().ToList();
            return View(SurveyList);
        }
        
        // GET: Survey/Create
        public ActionResult CreateSurvey()
        {
            GetSurveyAnswerType();
            return View();
        }

        // POST: Survey/Create
        [HttpPost]
        public ActionResult CreateSurvey(SurveyEntity Survey)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ValidationFactory VF = new ValidationFactory();
                    SurveyFactory AddSurvey = new SurveyFactory();
                    DataLayer.tblSurvey NewSurvey = new DataLayer.tblSurvey();
                    DataLayer.tblChannel NewChannel = new DataLayer.tblChannel();
                    string Message = VF.SurveyValidity(Survey.SurveyName, null);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("SurveyName", Message);
                       GetSurveyAnswerType();
                        return View(Survey);
                    }
                    else
                    {
                        NewSurvey.AnsTypeId = Survey.AnsTypeId;
                        NewSurvey.SurveyName = Survey.SurveyName;
                        NewSurvey.SurveyDescription = Survey.SurveyDescription;
                        NewSurvey.CompletionText = Survey.CompletionText;
                        NewSurvey.IsNeverExpire = Survey.IsNeverExpire;
                        NewSurvey.ExpiryDate = Survey.ExpiryDate;
                        NewSurvey.CreatedDate = DateTime.Now;
                        NewSurvey.CreatedBy = null;
                        NewSurvey.UpdatedDate = null;
                        NewSurvey.UpdatedBy = null;
                        NewSurvey.IsActive = true;
                        AddSurvey.SaveSurvey(NewSurvey);
                        return RedirectToAction("Survey");
                    }
                }
                else
                {
                   GetSurveyAnswerType();
                    return View(Survey);
                }



            }
            catch (Exception Ex)
            {
               GetSurveyAnswerType();
                return View();
            }
            finally
            {
               GetSurveyAnswerType();
            }
        }

        // GET: Survey/Edit/5
        public ActionResult EditSurvey(long id)
        {
            try
            {
                SurveyFactory EditSurvey = new SurveyFactory();
                SurveyEntity topic = new SurveyEntity();
                topic = EditSurvey.GetSurveyById(id);
                return View(topic);
            }
            catch
            {
                return View();
            }
            finally
            {
                GetSurveyAnswerType();
            }
        }

        // POST: Survey/Edit/5
        [HttpPost]
        public ActionResult EditSurvey(int id, SurveyEntity Survey)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SurveyFactory EditSurvey = new SurveyFactory();
                    DataLayer.tblSurvey NewSurvey = new DataLayer.tblSurvey();
                    ValidationFactory VF = new ValidationFactory();
                    string Message = VF.SurveyValidity(Survey.SurveyName, id);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("SurveyName", Message);
                        GetSurveyAnswerType();
                        return View(Survey);
                    }
                    else
                    {
                        NewSurvey.SurveyId = id;
                        NewSurvey.AnsTypeId = Survey.AnsTypeId;
                        NewSurvey.SurveyName = Survey.SurveyName;
                        NewSurvey.SurveyDescription = Survey.SurveyDescription;
                        NewSurvey.CompletionText = Survey.CompletionText;
                        NewSurvey.IsNeverExpire = Survey.IsNeverExpire;
                        NewSurvey.ExpiryDate = Survey.ExpiryDate;
                        NewSurvey.UpdatedDate = DateTime.Now;
                        NewSurvey.UpdatedBy = null;
                        NewSurvey.IsActive = Survey.IsActive;
                        EditSurvey.SaveSurvey(NewSurvey);
                        return RedirectToAction("Survey");
                    }


                }
                else
                {
                    return View(Survey);
                }
            }
            catch
            {
                return View();
            }
            finally
            {
                GetSurveyAnswerType();
            }
        }

        // GET: Survey/Delete/5
        public ActionResult DeleteSurvey(long id)
        {
            SurveyFactory EditSurvey = new SurveyFactory();
            SurveyEntity topic = new SurveyEntity();
            topic = EditSurvey.GetSurveyById(id);
            return View(topic);
        }

        // POST: Survey/Delete/5
        [HttpPost]
        public ActionResult DeleteSurvey(long id, FormCollection collection)
        {
            try
            {
                SurveyFactory DeleteSurvey = new SurveyFactory();
                SurveyEntity Survey = new SurveyEntity();
                Survey = DeleteSurvey.GetSurveyById(id);

                DataLayer.tblSurvey NewSurvey = new DataLayer.tblSurvey();
                NewSurvey.SurveyId = id;
                NewSurvey.AnsTypeId = Survey.AnsTypeId;
                NewSurvey.SurveyName = Survey.SurveyName;
                NewSurvey.SurveyDescription = Survey.SurveyDescription;
                NewSurvey.CompletionText = Survey.CompletionText;
                NewSurvey.IsNeverExpire = Survey.IsNeverExpire;
                NewSurvey.ExpiryDate = Survey.ExpiryDate;
                NewSurvey.CreatedDate = Survey.CreatedDate;
                NewSurvey.CreatedBy = Survey.CreatedBy;
                NewSurvey.UpdatedDate = DateTime.Now;
                NewSurvey.UpdatedBy = null;
                NewSurvey.IsActive = false; // IsActive will be false in delete record

                DeleteSurvey.SaveSurvey(NewSurvey);

                return RedirectToAction("Survey");
            }
            catch
            {
                return View();
            }
        }
    }
}
