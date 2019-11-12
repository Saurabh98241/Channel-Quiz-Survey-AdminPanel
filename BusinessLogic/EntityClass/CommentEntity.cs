using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class CommentEntity
    {
        public long BlogCommentId { get; set; }
        public Nullable<long> BlogId { get; set; }
        public Nullable<long> BlogCommentByUserId { get; set; }
        public string Comment { get; set; }
    }
}
