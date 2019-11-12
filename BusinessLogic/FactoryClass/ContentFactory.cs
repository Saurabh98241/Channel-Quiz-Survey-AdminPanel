using BusinessLogic.EntityClass;
using System.Linq;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLogic.FactoryClass
{
   public class ContentFactory :BaseClass
    {
        public List<ChannelEntity> GetChannel()
        {
            List<ChannelEntity> Channel = new List<ChannelEntity>();
            Channel = db.tblChannels.Where(x => x.IsActive == true).Select(x => new ChannelEntity() {
                ChannelId = x.ChannelId,
                ChannelName = x.ChannelName
            }).ToList();
            return Channel;
        }
        public List<TopicEntity> GetTopic(long Id)
        {
            List<TopicEntity> topic = new List<TopicEntity>();
            topic = db.tblTopics.Where(x => x.TopicId == Id && x.IsActive == true).Select(x => new TopicEntity()
            {
               TopicId = x.TopicId,
               TopicName = x.TopicName
            }).ToList();
            return topic;
        }

        public List<BlogEntity> GetBlogByTopicId(long TopicId)
        {
            List<BlogEntity> topic = new List<BlogEntity>();
            topic = db.tblBlogs.Where(x => x.TopicId == TopicId && x.IsActive == true).Select(x => new BlogEntity()
            {   TopicId = x.TopicId,
                BlogId = x.BlogId,
                BlogName = x.BlogName,
                BlogHeading = x.BlogHeading
            }).ToList();


            return topic;
        }

        //public List<CommentEntity> GetCommentByMultileBlog(string strComment)
        //{

        //    List<tblBlogComment> Comment = new List<tblBlogComment>();

        //    Comment = db.GetCommentByMultipleBlog(strComment);
        //}

        //public GetCommentByBlogId()
        // {

        // }
    }
}
