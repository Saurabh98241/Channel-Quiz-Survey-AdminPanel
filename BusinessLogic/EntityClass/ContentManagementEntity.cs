using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class ContentManagementEntity
    {
        public List<CommentEntity> CommentEntity { get; set; }
        public List<LikeEntity> LikeEntity { get; set; }
        public List<ContentEntity> ContentEntity { get; set; }
    }
}
