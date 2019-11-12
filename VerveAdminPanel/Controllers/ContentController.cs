using BusinessLogic.EntityClass;
using BusinessLogic.FactoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerveAdminPanel.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult ContentManagement()
        {
            ContentFactory cf = new ContentFactory();
            List<ChannelEntity> Channel = cf.GetChannel();
            ViewBag.Channel = new SelectList(Channel, "ChannelId", "ChannelName");
            return View();
        }
        public JsonResult GetTopics(string id)
        {
            if (id != null && id != "")
            {
                List<SelectListItem> funds = new List<SelectListItem>();
                ContentFactory cf = new ContentFactory();
                var topicList = cf.GetTopic(Convert.ToInt64(id));
                var topicData = topicList.Select(m => new SelectListItem()
                {
                    Text = m.TopicName,
                    Value = m.TopicId.ToString(),
                });
                return Json(topicData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("<span class='MarginTop10' style='color:red;padding:5px;font-size:14px;'>Please select Channel</span>", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GetBlog(string id)
        {
            
                List<SelectListItem> funds = new List<SelectListItem>();
                ContentFactory cf = new ContentFactory();
                var topicList = cf.GetTopic(Convert.ToInt64(id)); 
                var topicData = topicList.Select(m => new SelectListItem()
                {
                    Text = m.TopicName,
                    Value = m.TopicId.ToString(),
                });
                var topic = topicList[0];
                long TopicID = topic.TopicId;
                List<BlogEntity> BlogByTopic = new List<BlogEntity>();
                BlogByTopic = cf.GetBlogByTopicId(TopicID);
                ViewBag.Blogs = BlogByTopic;
            CommentFactory cmf = new CommentFactory();
            List<CommentEntity> ListComment = new List<CommentEntity>();
            ListComment = cmf.GetComment();
            ViewBag.Comments = ListComment;

            LikeFactory lf = new LikeFactory();
            List<LikeEntity> ListLike = new List<LikeEntity>();
            ListLike = lf.GetLike();
            ViewBag.Likes = ListLike;

            List<CommentEntity> Comment = new List<CommentEntity>();
                string s = string.Empty;
                foreach (var item in BlogByTopic)
                {
                     s += item.BlogId + ",";
                }


            return PartialView("_LoadBlogs");

            //return Json(topicData, JsonRequestBehavior.AllowGet);
            
        }
    }
}