using BusinessLogic.EntityClass;
using BusinessLogic.FactoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerveAdminPanel.Controllers
{
    public class BlogController : Controller
    {
        public void GetTopic()
        {
            TopicFactory UF = new TopicFactory();
            List<TopicEntity> TopicList = UF.GetTopic().ToList();
            ViewBag.Topics = new SelectList(TopicList, "TopicId", "TopicName");
        }


        // GET: Blog
        public ActionResult Blog()
        {
            BlogFactory TF = new BlogFactory();
            List<BlogEntity> BlogList = TF.GetBlog().ToList();
            return View(BlogList);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blog/Create
        public ActionResult CreateBlog()
        {
            GetTopic();
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult CreateBlog(BlogEntity Blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ValidationFactory VF = new ValidationFactory();
                    BlogFactory AddBlog = new BlogFactory();
                    DataLayer.tblBlog NewBlog = new DataLayer.tblBlog();
                    DataLayer.tblChannel NewChannel = new DataLayer.tblChannel();
                    string Message = VF.BlogValidity(Blog.BlogName, null);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("BlogName", Message);
                        GetTopic();
                        return View(Blog);
                    }
                    else
                    {
                        NewBlog.BlogName = Blog.BlogName;
                        NewBlog.BlogHeading = Blog.BlogHeading;
                        NewBlog.TopicId = Blog.TopicId;
                        NewBlog.CreatedDate = DateTime.Now;
                        NewBlog.CreatedBy = null;
                        NewBlog.UpdatedDate = null;
                        NewBlog.UpdatedBy = null;
                        NewBlog.IsActive = true;
                        AddBlog.SaveBlog(NewBlog);
                        return RedirectToAction("Blog");
                    }
                }
                else
                {
                    GetTopic();
                    return View(Blog);
                }



            }
            catch (Exception Ex)
            {
                GetTopic();
                return View();
            }
            finally { GetTopic(); }
        }

        // GET: Blog/Edit/5
        public ActionResult EditBlog(long id)
        {
            try
            {
                BlogFactory EditBlog = new BlogFactory();
                BlogEntity Blog = new BlogEntity();
                Blog = EditBlog.GetBlogById(id);
                return View(Blog);
            }
            catch
            {
                return View();
            }
            finally
            {
                GetTopic();
            }

        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult EditBlog(int id, BlogEntity Blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BlogFactory EditBlog = new BlogFactory();
                    DataLayer.tblBlog NewBlog = new DataLayer.tblBlog();
                    ValidationFactory VF = new ValidationFactory();
                    string Message = VF.BlogValidity(Blog.BlogName, id);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("BlogName", Message);
                        GetTopic();
                        return View(Blog);
                    }
                    else
                    {
                        NewBlog.BlogId = id;
                        NewBlog.TopicId = Blog.TopicId;
                        NewBlog.BlogName = Blog.BlogName;
                        NewBlog.BlogHeading = Blog.BlogHeading;
                        NewBlog.CreatedDate = Blog.CreatedDate;
                        NewBlog.CreatedBy = null;
                        NewBlog.UpdatedDate = DateTime.Now;
                        NewBlog.UpdatedBy = null;
                        NewBlog.IsActive = Blog.IsActive;
                        EditBlog.SaveBlog(NewBlog);
                        return RedirectToAction("Blog");
                    }
                }
                else
                {
                    return View(Blog);
                }
            }
            catch
            {
                return View();
            }
            finally
            {
                GetTopic();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult DeleteBlog(long id)
        {
            BlogFactory EditBlog = new BlogFactory();
            BlogEntity Blog = new BlogEntity();
            Blog = EditBlog.GetBlogById(id);
            return View(Blog);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult DeleteBlog(long id, FormCollection collection)
        {
            try
            {
                BlogFactory DeleteBlog = new BlogFactory();
                BlogEntity Blog = new BlogEntity();
                Blog = DeleteBlog.GetBlogById(id);
                DataLayer.tblBlog NewBlog = new DataLayer.tblBlog();
                NewBlog.BlogId = id;
                NewBlog.TopicId = Blog.TopicId;
                NewBlog.BlogName = Blog.BlogName;
                NewBlog.BlogHeading = Blog.BlogHeading;
                NewBlog.CreatedDate = Blog.CreatedDate;
                NewBlog.CreatedBy = Blog.CreatedBy;
                NewBlog.UpdatedDate = DateTime.Now;
                NewBlog.UpdatedBy = null;
                NewBlog.IsActive = false; // IsActive will be false in delete record
                DeleteBlog.SaveBlog(NewBlog);
                return RedirectToAction("Blog");
            }
            catch
            {
                return View();
            }
        }
    }
}
