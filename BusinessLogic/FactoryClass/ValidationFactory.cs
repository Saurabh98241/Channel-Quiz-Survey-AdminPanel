using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.EntityClass;
using DataLayer;
using System.Data.Entity;

namespace BusinessLogic.FactoryClass
{
    public class ValidationFactory : BaseClass
    {
        public string UserValidity(string UserName , long? UserId)
        {
            UserEntity User = new UserEntity();
            if (UserId != null)
            {
                User = db.tblUsers.Where(x => x.UserName.ToLower() == UserName.ToLower() && x.UserId != UserId).Select(x => new UserEntity()
                {
                    UserName = x.UserName,
                    Email = x.Email
                }).FirstOrDefault();
            }
            else
            {
                User = db.tblUsers.Where(x => x.UserName.ToLower() == UserName.ToLower()).Select(x => new UserEntity()
                {
                    UserName = x.UserName,
                    Email = x.Email
                }).FirstOrDefault();
            }

           
            //List<UserEntity> usrList = new List<UserEntity>();
            //var Usr = usrList.FirstOrDefault(x => x.UserName.ToLower() == UserName.ToLower());
            if (User != null)
            {
                return "User already exist.";
            }
            else
            {
                return "Success";
            }
        }
        public string ChannelValidity(string ChannelName, long? ChannelId)
        {
            ChannelEntity Channel = new ChannelEntity();
            if (ChannelId != null)
            {
                Channel = db.tblChannels.Where(x => x.ChannelName.ToLower() == ChannelName.ToLower() && x.ChannelId != ChannelId).Select(x => new ChannelEntity()
                {
                    ChannelName = x.ChannelName,
                }).FirstOrDefault();
            }
            else
            {
                Channel = db.tblChannels.Where(x => x.ChannelName.ToLower() == ChannelName.ToLower()).Select(x => new ChannelEntity()
                {

                    ChannelName = x.ChannelName,

                }).FirstOrDefault();
            }

            List<ChannelEntity> usrList = new List<ChannelEntity>();
            //var Usr = usrList.FirstOrDefault(x => x.ChannelName.ToLower() == ChannelName.ToLower());
            if (Channel != null)
            {
                return "Channel already exist.";
            }
            else
            {
                return "Success";
            }
        }
        public string QuizValidity(string QuizName, long? QuizId)
        {
            QuizEntity Quiz = new QuizEntity();
            if (QuizId != null)
            {
                Quiz = db.tblQuizs.Where(x => x.QuizName.ToLower() == QuizName.ToLower() && x.QuizId != QuizId).Select(x => new QuizEntity()
                {
                    QuizName = x.QuizName,
                }).FirstOrDefault();
            }
            else
            {
                Quiz = db.tblQuizs.Where(x => x.QuizName.ToLower() == QuizName.ToLower()).Select(x => new QuizEntity()
                {

                    QuizName = x.QuizName,

                }).FirstOrDefault();
            }

            List<QuizEntity> usrList = new List<QuizEntity>();
            //var Usr = usrList.FirstOrDefault(x => x.QuizName.ToLower() == QuizName.ToLower());
            if (Quiz != null)
            {
                return "Quiz already exist.";
            }
            else
            {
                return "Success";
            }
        }
        public string TopicValidity(string TopicName, long? TopicId)
        {
            List<TopicEntity> usrList = new List<TopicEntity>();
            TopicEntity Topic = new TopicEntity();
            if (TopicId != null)
            {
                Topic = db.tblTopics.Where(x => x.TopicName.ToLower() == TopicName.ToLower() && x.TopicId != TopicId).Select(x => new TopicEntity()
                {
                    TopicName = x.TopicName,

                }).FirstOrDefault();
            }
            else
            {
                Topic = db.tblTopics.Where(x => x.TopicName.ToLower() == TopicName.ToLower()).Select(x => new TopicEntity()
                {
                    TopicName = x.TopicName,
                }).FirstOrDefault();
            }

            // var Usr = usrList.FirstOrDefault(x => x.TopicName.ToLower() == TopicName.ToLower());
            if (Topic != null)
            {
                return "Topic already exist.";
            }
            else
            {
                return "Success";
            }
        }

        public string QuestionValidity(string QuestionName, long? QuestionId)
        {
            List<QuestionEntity> usrList = new List<QuestionEntity>();
            QuestionEntity Question = new QuestionEntity();
            if (QuestionId != null)
            {
                Question = db.tblQuestions.Where(x => x.Question.ToLower() == QuestionName.ToLower() && x.QuestionId != QuestionId).Select(x => new QuestionEntity()
                {
                    Question = x.Question,

                }).FirstOrDefault();
            }
            else
            {
                Question = db.tblQuestions.Where(x => x.Question.ToLower() == QuestionName.ToLower()).Select(x => new QuestionEntity()
                {
                    Question = x.Question,
                }).FirstOrDefault();
            }
            if (Question != null)
            {
                return "Question already exist.";
            }
            else
            {
                return "Success";
            }
        }

        public string OptionValidity(string optName, long? OptionId, long QuestionId)
        {
            List<QuestionOptionMappingEntity> usrList = new List<QuestionOptionMappingEntity>();
            QuestionOptionMappingEntity Question = new QuestionOptionMappingEntity();
            if (OptionId != null)
            {
                Question = db.tblQuestionOptionMappings.Where(x => x.QuestionOptionText.ToLower() == optName.ToLower() && x.OptionId != OptionId).Select(x => new QuestionOptionMappingEntity()
                {
                    QuestionOptionText = x.QuestionOptionText,

                }).FirstOrDefault();
            }
            else
            {
                Question = db.tblQuestionOptionMappings.Where(x => x.QuestionOptionText.ToLower() == optName.ToLower() && x.QuestionId == QuestionId).Select(x => new QuestionOptionMappingEntity()
                {
                    QuestionOptionText = x.QuestionOptionText,
                }).FirstOrDefault();
            }
            if (Question != null)
            {
                return "Question already exist.";
            }
            else
            {
                return "Success";
            }
        }

        //BlogValidity
        public string BlogValidity(string BlogName, long? BlogId)
        {
            List<BlogEntity> usrList = new List<BlogEntity>();
            BlogEntity Blog = new BlogEntity();
            if (BlogId != null)
            {
                Blog = db.tblBlogs.Where(x => x.BlogName.ToLower() == BlogName.ToLower() && x.BlogId != BlogId).Select(x => new BlogEntity()
                {
                    BlogName = x.BlogName,

                }).FirstOrDefault();
            }
            else
            {
                Blog = db.tblBlogs.Where(x => x.BlogName.ToLower() == BlogName.ToLower()).Select(x => new BlogEntity()
                {
                    BlogName = x.BlogName,
                }).FirstOrDefault();
            }

            
            if (Blog != null)
            {
                return "Blog already exist.";
            }
            else
            {
                return "Success";
            }
        }


        public string SurveyValidity(string SurveyName, long? SurveyId)
        {
            List<SurveyEntity> usrList = new List<SurveyEntity>();
            SurveyEntity Survey = new SurveyEntity();
            if (SurveyId != null)
            {
                Survey = db.tblSurveys.Where(x => x.SurveyName.ToLower() == SurveyName.ToLower() && x.SurveyId != SurveyId).Select(x => new SurveyEntity()
                {
                    SurveyName = x.SurveyName,

                }).FirstOrDefault();
            }
            else
            {
                Survey = db.tblSurveys.Where(x => x.SurveyName.ToLower() == SurveyName.ToLower()).Select(x => new SurveyEntity()
                {
                    SurveyName = x.SurveyName,
                }).FirstOrDefault();
            }


            if (Survey != null)
            {
                return "Survey already exist.";
            }
            else
            {
                return "Success";
            }
        }
    }
}
