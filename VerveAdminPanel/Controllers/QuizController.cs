using BusinessLogic.EntityClass;
using BusinessLogic.FactoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerveAdminPanel.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Quiz()
        {
            QuizFactory qf = new QuizFactory();
            List<QuizEntity> QuizList = qf.GetQuiz().ToList();
            return View(QuizList);
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quiz/Create
        public ActionResult CreateQuiz()
        {
            return View();
        }

        // POST: Quiz/Create
        [HttpPost]
        public ActionResult CreateQuiz(QuizEntity Quiz)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ValidationFactory VF = new ValidationFactory();
                    QuizFactory AddQuiz = new QuizFactory();
                    DataLayer.tblQuiz NewQuiz = new DataLayer.tblQuiz();
                    string Message = VF.QuizValidity(Quiz.QuizName, null);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("QuizName", Message);
                        return View(Quiz);
                    }
                    else
                    {
                        NewQuiz.QuizName = Quiz.QuizName;
                        NewQuiz.CreatedDate = DateTime.Now;
                        NewQuiz.CreatedBy = null;
                        NewQuiz.UpdatedDate = null;
                        NewQuiz.UpdatedBy = null;
                        NewQuiz.IsActive = true;
                        AddQuiz.SaveQuiz(NewQuiz);
                        return RedirectToAction("Quiz");
                    }
                }
                else
                {

                    return View(Quiz);
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: Quiz/Edit/5
        public ActionResult EditQuiz(int id)
        {
            QuizFactory EditQuiz = new QuizFactory();
            QuizEntity quiz = new QuizEntity();
            quiz = EditQuiz.GetQuizById(id);
            return View(quiz);
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        public ActionResult EditQuiz(int id, QuizEntity Quiz)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    QuizFactory EditQuiz = new QuizFactory();
                    DataLayer.tblQuiz NewQuiz = new DataLayer.tblQuiz();

                    ValidationFactory VF = new ValidationFactory();
                    string Message = VF.QuizValidity(Quiz.QuizName, id);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("QuizName", Message);
                        return View(Quiz);
                    }
                    else
                    {
                        NewQuiz.QuizId = id;
                        NewQuiz.QuizName = Quiz.QuizName;
                        NewQuiz.CreatedDate = Quiz.CreatedDate;
                        NewQuiz.CreatedBy = null;
                        NewQuiz.UpdatedDate = DateTime.Now;
                        NewQuiz.UpdatedBy = null;
                        NewQuiz.IsActive = Quiz.IsActive;
                        EditQuiz.SaveQuiz(NewQuiz);
                        return RedirectToAction("Quiz");
                    }


                }
                else
                {
                    return View(Quiz);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Delete/5
        [HttpGet]
        public ActionResult DeleteQuiz(int id)
        {
            QuizFactory EditQuiz = new QuizFactory();
            QuizEntity channel = new QuizEntity();
            channel = EditQuiz.GetQuizById(id);
            return View(channel);
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        public ActionResult DeleteQuiz(long id)
        {
            try
            {
                QuizFactory DeleteQuiz = new QuizFactory();
                QuizEntity Quiz = new QuizEntity();
                Quiz = DeleteQuiz.GetQuizById(id);

                DataLayer.tblQuiz NewQuiz = new DataLayer.tblQuiz();
                NewQuiz.QuizId = id;

                NewQuiz.QuizName = Quiz.QuizName;
                NewQuiz.CreatedDate = Quiz.CreatedDate;
                NewQuiz.CreatedBy = Quiz.CreatedBy;
                NewQuiz.UpdatedDate = DateTime.Now;
                NewQuiz.UpdatedBy = null;
                NewQuiz.IsActive = false; // IsActive will be false in delete record

                DeleteQuiz.SaveQuiz(NewQuiz);

                return RedirectToAction("Quiz");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult QuizResult()
        {
            GetUser();
            
            return View();
        }
        public void GetUser()
        {
            UserFactory uf = new UserFactory();
            List<UserEntity> user = uf.GetUser();
            ViewBag.User = new SelectList(user, "UserId", "UserName");
        }
    }
}