using BusinessLogic.EntityClass;
using BusinessLogic.FactoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerveAdminPanel.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question

        public void GetQuiz()
        {
            QuizFactory UF = new QuizFactory();
            List<QuizEntity> QuizList = UF.GetQuiz().ToList();
            ViewBag.Quizs = new SelectList(QuizList, "QuizId", "QuizName");
        }


        public ActionResult Question()
        {
            QuestionFactory TF = new QuestionFactory();
            List<QuestionEntity> QuestionList = TF.GetQuestion().ToList();
            return View(QuestionList);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult AddQuestion()
        {
            GetQuiz();
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult AddQuestion(QuestionEntity questionEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ValidationFactory VF = new ValidationFactory();
                    QuestionFactory AddQuestion = new QuestionFactory();
                    DataLayer.tblQuestion NewQuestion = new DataLayer.tblQuestion();
                    DataLayer.tblQuiz NewQuiz = new DataLayer.tblQuiz();
                    string Message = VF.QuestionValidity(questionEntity.Question, null);
                  
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("Question", Message);
                        GetQuiz();
                        return View(questionEntity);
                    }
                    else
                    {
                        NewQuestion.Question = questionEntity.Question;
                        NewQuestion.QuizId = questionEntity.QuizId;
                        NewQuestion.IsMultiple = questionEntity.IsMultiple;
                        NewQuestion.CreatedDate = DateTime.Now;
                        NewQuestion.CreatedBy = null;
                        NewQuestion.UpdatedDate = null;
                        NewQuestion.UpdatedBy = null;
                        NewQuestion.IsActive = true;
                        AddQuestion.SaveQuestion(NewQuestion);
                        return RedirectToAction("Question");
                    }
                }
                else
                {
                    GetQuiz();
                    return View(questionEntity);
                }
            }
            catch (Exception Ex)
            {
                return View();
            }
            finally
            {
                GetQuiz();
            }
        }

        // GET: Question/Edit/5
        public ActionResult EditQuestion(long id)
        {
            try
            {
                QuestionFactory EditQuestion = new QuestionFactory();
                QuestionEntity topic = new QuestionEntity();
                topic = EditQuestion.GetQuestionById(id);
                return View(topic);
            }
            catch
            {
                return View();
            }
            finally
            {
                GetQuiz();
            }


        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult EditQuestion(long id, QuestionEntity questionEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    QuestionFactory EditQuestion = new QuestionFactory();
                    DataLayer.tblQuestion NewQuestion = new DataLayer.tblQuestion();
                    ValidationFactory VF = new ValidationFactory();
                    string Message = VF.QuestionValidity(questionEntity.Question, id);
                   
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("QuestionName", Message);
                        GetQuiz();
                        return View(questionEntity);
                    }
                    else
                    {
                        NewQuestion.QuestionId = id;
                        NewQuestion.Question = questionEntity.Question;
                        NewQuestion.CreatedDate = questionEntity.CreatedDate;
                        NewQuestion.CreatedBy = null;
                        NewQuestion.QuizId = questionEntity.QuizId;
                        NewQuestion.UpdatedDate = DateTime.Now;
                        NewQuestion.UpdatedBy = null;
                        NewQuestion.IsActive = questionEntity.IsActive;
                        EditQuestion.SaveQuestion(NewQuestion);
                        return RedirectToAction("Question");
                    }


                }
                else
                {
                    return View(questionEntity);
                }
            }
            catch
            {
                return View();
            }
            finally
            {
                GetQuiz();
            }
        }

        // GET: Question/Delete/5
        public ActionResult DeleteQuestion(long id)
        {
            QuestionFactory EditQuestion = new QuestionFactory();
            QuestionEntity topic = new QuestionEntity();
            topic = EditQuestion.GetQuestionById(id);
            return View(topic);
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult DeleteQuestion(long id, FormCollection collection)
        {
            try
            {
                QuestionFactory DeleteQuestion = new QuestionFactory();
                QuestionEntity Question = new QuestionEntity();
                Question = DeleteQuestion.GetQuestionById(id);

                DataLayer.tblQuestion NewQuestion = new DataLayer.tblQuestion();
                NewQuestion.QuestionId = id;
                NewQuestion.QuizId = Question.QuizId;
                NewQuestion.Question = Question.Question;
                NewQuestion.CreatedDate = Question.CreatedDate;
                NewQuestion.CreatedBy = Question.CreatedBy;
                NewQuestion.UpdatedDate = DateTime.Now;
                NewQuestion.UpdatedBy = null;
                NewQuestion.IsActive = false; // IsActive will be false in delete record

                DeleteQuestion.SaveQuestion(NewQuestion);

                return RedirectToAction("Question");
            }
            catch
            {
                return View();
            }
        }

        //POST: Save Option
        public JsonResult AddOption(QuestionOptionMappingEntity queOp)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    ValidationFactory VF = new ValidationFactory();
                    QuestionOptionMappingFactory AddOption = new QuestionOptionMappingFactory();
                    DataLayer.tblQuestionOptionMapping NewQO = new DataLayer.tblQuestionOptionMapping();
                    DataLayer.tblQuiz NewQuiz = new DataLayer.tblQuiz();
                    string Message = VF.OptionValidity(queOp.QuestionOptionText, null, queOp.QuestionId);
                   
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("Question", Message);
                        GetQuiz();
                        return Json("Option Already Exist.", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        NewQO.QuestionId = queOp.QuestionId;
                        NewQO.QuestionOptionText = queOp.QuestionOptionText;
                        NewQO.IsTrue = queOp.IsTrue;
                        NewQO.CreatedDate = DateTime.Now;
                        NewQO.CreatedBy = null;
                        NewQO.UpdatedDate = null;
                        NewQO.UpdatedBy = null;
                        NewQO.IsActive = true;
                        AddOption.SaveOption(NewQO);
                        return Json("Record added sucessfully", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    GetQuiz();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                return Json("Something went wrong.", JsonRequestBehavior.AllowGet);
            }
            finally
            {
                GetQuiz();
            }

            
        }
    }
}