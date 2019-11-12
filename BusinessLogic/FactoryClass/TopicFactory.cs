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
   public class TopicFactory : BaseClass
    {
        public List<TopicEntity> GetTopic1()
        {
            List<TopicEntity> ListTopic = new List<TopicEntity>();
            ListTopic = db.tblTopics.OrderByDescending(x => x.TopicId).Where(x => x.IsActive == true).Select(x => new TopicEntity()
            {
                TopicId = x.TopicId,
                TopicName = x.TopicName,
                ChannelId = x.ChannelId

            }).ToList();
            return ListTopic;


        }
        public List<TopicEntity> GetTopic()
        {
            List<TopicEntity> ListTopic = new List<TopicEntity>();
            ListTopic = (from t in db.tblTopics
                         join c in db.tblChannels on t.ChannelId equals c.ChannelId where t.IsActive== true
                         select new TopicEntity() {
                             TopicId = t.TopicId,
                             TopicName =t.TopicName,
                             ChannelId = t.ChannelId,
                             ChannelName = c.ChannelName
                         }).ToList();

            return ListTopic;
        }
        public void SaveTopic(tblTopic Topic)
        {
            if (Topic.TopicId == 0)
            {
                db.tblTopics.Add(Topic);
            }
            else
            {
                db.Entry(Topic).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public TopicEntity GetTopicById(long Id)
        {
            TopicEntity Topic = new TopicEntity();
            Topic = db.tblTopics.Where(x => x.TopicId == Id).Select(x => new TopicEntity()
            {
                ChannelId = x.ChannelId,
               
                TopicName = x.TopicName,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                IsActive = x.IsActive
            }).FirstOrDefault();
            return Topic;
        }
    }
}
