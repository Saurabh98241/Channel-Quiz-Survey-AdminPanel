using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class ContentEntity
    {
        public ChannelEntity Channel { get; set; }
        public TopicEntity Topic { get; set; }
        public BlogEntity Blog { get; set; }
        public List<LikeEntity> LikeEntity { get; set; }
       
    }
 
}
