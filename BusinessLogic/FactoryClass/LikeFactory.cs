using BusinessLogic.EntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.FactoryClass
{
   public class LikeFactory : BaseClass
    {
        public List<LikeEntity> GetLike()
        {
            List<LikeEntity> List = new List<LikeEntity>();
            List = db.tblBlogLikes.Select(x => new LikeEntity()
            {
                BlogLikeId = x.BlogLikeId,
                BlogId = x.BlogId,
                BlogLikedByUserId = x.BlogLikedByUserId,
                Like = x.Like

            }).ToList();
            return List;
        }
    }
}
