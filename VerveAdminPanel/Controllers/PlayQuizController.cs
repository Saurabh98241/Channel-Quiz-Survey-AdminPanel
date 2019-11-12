using BusinessLogic.EntityClass;
using BusinessLogic.FactoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerveAdminPanel.Controllers
{
    public class PlayQuizController : Controller
    {
        // GET: PlayQuiz
        public ActionResult UserQuizList()
        {
            QuizFactory qf = new QuizFactory();
            List<QuizEntity> QuizList = qf.GetQuiz().ToList();
            ViewBag.QuizList = QuizList;
            return View(QuizList);
        }
        public ActionResult GetQuiz(long QuizId)
        {
            Session["QuizId"] = QuizId;
            QuizFactory EditQuiz = new QuizFactory();
            QuizEntity quiz = new QuizEntity();
            quiz = EditQuiz.GetQuizById(QuizId);
            ViewBag.QuizName = quiz.QuizName;

            UserQuizEntity userQuiz = new UserQuizEntity();
            PlayQuizFactory qf = new PlayQuizFactory();
            List<QuestionEntity> QuestionListByQuiz = qf.GetQuestionsByQuizId(QuizId).ToList();
            ViewBag.QuestionList = QuestionListByQuiz;
            userQuiz.QuestionEntity = QuestionListByQuiz;
           
          //  ViewBag.QuizListByQuiz = QuizListByQuiz;
            List<QuestionOptionMappingEntity> Options = qf.GetOption();
            ViewBag.OptionList = Options;
            userQuiz.QuestionOptionMappingEntity = Options;
            // ViewBag.OptionList = Options;
            return View(userQuiz);
        }

        [HttpPost]
        public JsonResult SaveQuiz(List<QuestionOptionMappingEntity> resultQuiz)
        {
            QuestionOptionMappingFactory isTrue = new QuestionOptionMappingFactory();
            DataLayer.tblUserQuestionAnswer ansEntity = new DataLayer.tblUserQuestionAnswer();
            UserQuestionAnswerFactory ansFactory = new UserQuestionAnswerFactory();
            if (resultQuiz != null)
            {
                foreach (var item in resultQuiz)
                {
                    ansEntity.UserId = 4;
                    ansEntity.QuizId = Convert.ToInt64(Session["QuizId"].ToString());
                    ansEntity.QuestionId = item.QuestionId;
                    ansEntity.SelectedAns = item.QuestionOptionText;
                    ansEntity.IsTrueAns = isTrue.IsTrueAnswer(item.QuestionOptionText, item.QuestionId);
                    ansEntity.AnswerDate = DateTime.Now;
                    ansFactory.SaveUserAnswer(ansEntity);

                }
                return Json("Quiz added successfully", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Failed, Something went wrong", JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}