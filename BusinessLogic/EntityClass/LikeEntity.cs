using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class LikeEntity
    {
        public long BlogLikeId { get; set; }
        public Nullable<long> BlogId { get; set; }
        public Nullable<long> BlogLikedByUserId { get; set; }
        public Nullable<bool> Like { get; set; }
    }
}
