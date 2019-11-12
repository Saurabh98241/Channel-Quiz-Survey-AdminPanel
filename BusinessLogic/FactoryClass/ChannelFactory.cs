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
   public class ChannelFactory : BaseClass
    {
        public List<ChannelEntity> GetChannel()
        {
            List<ChannelEntity> ListChannel = new List<ChannelEntity>();
            ListChannel = db.tblChannels.OrderByDescending(x=>x.ChannelId).Where(x => x.IsActive == true).Select(x => new ChannelEntity()
            {
               ChannelId = x.ChannelId,
               ChannelName = x.ChannelName

            }).ToList();
            return ListChannel;
        }
        public void SaveChannel(tblChannel Channel)
        {
            if (Channel.ChannelId == 0)
            {
                db.tblChannels.Add(Channel);
            }
            else
            {
                db.Entry(Channel).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public ChannelEntity GetChannelById(long Id)
        {
            ChannelEntity Channel = new ChannelEntity();
            Channel = db.tblChannels.Where(x => x.ChannelId == Id).Select(x => new ChannelEntity()
            {
                ChannelName = x.ChannelName,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                IsActive = x.IsActive
            }).FirstOrDefault();
            return Channel;
        }
        
    }
}
