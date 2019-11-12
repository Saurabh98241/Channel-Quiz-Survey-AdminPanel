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
   public class BlogFactory :BaseClass
    {
        public List<BlogEntity> GetBlog()
        {
            List<BlogEntity> ListBlog = new List<BlogEntity>();
            ListBlog = (from b in db.tblBlogs
                         join c in db.tblTopics on b.TopicId equals c.TopicId
                        where b.IsActive == true
                         select new BlogEntity()
                         {
                             BlogId = b.BlogId,
                             BlogName = b.BlogName,
                             BlogHeading = b.BlogHeading,
                             TopicId = c.TopicId,
                             TopicName = c.TopicName
                         }).ToList();

            return ListBlog;
        }
        public void SaveBlog(tblBlog Blog)
        {
            if (Blog.BlogId == 0)
            {
                db.tblBlogs.Add(Blog);
            }
            else
            {
                db.Entry(Blog).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public BlogEntity GetBlogById(long Id)
        {
            BlogEntity Blog = new BlogEntity();
            Blog = db.tblBlogs.Where(x => x.BlogId == Id).Select(x => new BlogEntity()
            {
                TopicId = x.TopicId,
                BlogName = x.BlogName,
                BlogHeading = x.BlogHeading,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                IsActive = x.IsActive
            }).FirstOrDefault();
            return Blog;
        }
    }
}
