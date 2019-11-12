using BusinessLogic.EntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.FactoryClass
{
    public class CommentFactory : BaseClass
    {
        public List<CommentEntity> GetComment()
        {
            List<CommentEntity> ListComment = new List<CommentEntity>();
            ListComment = db.tblBlogComments.Select(x => new CommentEntity()
            {
               BlogCommentId = x.BlogCommentId,
               BlogId = x.BlogId,
               BlogCommentByUserId = x.BlogCommentByUserId,
               Comment = x.Comment

            }).ToList();
            return ListComment;
        }
    }
}
