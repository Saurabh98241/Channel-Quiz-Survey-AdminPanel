using BusinessLogic.EntityClass;
using BusinessLogic.FactoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerveAdminPanel.Controllers
{
    public class TopicController : Controller
    {
        // GET: Topic

        public void GetChannel()
        {
            ChannelFactory UF = new ChannelFactory();
            List<ChannelEntity> ChannelList = UF.GetChannel().ToList();
            ViewBag.Channels = new SelectList(ChannelList, "ChannelId", "ChannelName");
        }


        public ActionResult Topic()
        {
            TopicFactory TF = new TopicFactory();
            List<TopicEntity> TopicList = TF.GetTopic().ToList();
            return View(TopicList);
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Topic/Create
        public ActionResult AddTopic()
        {
            GetChannel();
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult AddTopic(TopicEntity Topic)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ValidationFactory VF = new ValidationFactory();
                    TopicFactory AddTopic = new TopicFactory();
                    DataLayer.tblTopic NewTopic = new DataLayer.tblTopic();
                    DataLayer.tblChannel NewChannel = new DataLayer.tblChannel();
                    string Message = VF.TopicValidity(Topic.TopicName, null);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("TopicName", Message);
                        GetChannel();
                        return View(Topic);
                    }
                    else
                    {
                        NewTopic.TopicName = Topic.TopicName;
                        NewTopic.ChannelId = Topic.ChannelId;
                        NewTopic.CreatedDate = DateTime.Now;
                        NewTopic.CreatedBy = null;
                        NewTopic.UpdatedDate = null;
                        NewTopic.UpdatedBy = null;
                        NewTopic.IsActive = true;
                        AddTopic.SaveTopic(NewTopic);
                        return RedirectToAction("Topic");
                    }
                }
                else
                {
                    GetChannel();
                    return View(Topic);
                }



            }
            catch (Exception Ex)
            {
                GetChannel();
                return View();
            }
            finally
            {
                GetChannel();
            }
        }

        // GET: Topic/Edit/5
        public ActionResult EditTopic(long id)
        {
            try
            {
                TopicFactory EditTopic = new TopicFactory();
                TopicEntity topic = new TopicEntity();
                topic = EditTopic.GetTopicById(id);
                return View(topic);
            }
            catch
            {
                return View();
            }
            finally {
                GetChannel();
            }
           
            
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult EditTopic(long id, TopicEntity Topic)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TopicFactory EditTopic = new TopicFactory();
                    DataLayer.tblTopic NewTopic = new DataLayer.tblTopic();
                    ValidationFactory VF = new ValidationFactory();
                    string Message = VF.TopicValidity(Topic.TopicName, id);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("TopicName", Message);
                        GetChannel();
                        return View(Topic);
                    }
                    else
                    {
                        NewTopic.TopicId = id;
                        NewTopic.TopicName = Topic.TopicName;
                        NewTopic.CreatedDate = Topic.CreatedDate;
                        NewTopic.CreatedBy = null;
                        NewTopic.ChannelId = Topic.ChannelId;
                        NewTopic.UpdatedDate = DateTime.Now;
                        NewTopic.UpdatedBy = null;
                        NewTopic.IsActive = Topic.IsActive;
                        EditTopic.SaveTopic(NewTopic);
                        return RedirectToAction("Topic");
                    }


                }
                else
                {
                    return View(Topic);
                }
            }
            catch
            {
                return View();
            }
            finally
            {
                GetChannel();
            }
        }

        // GET: Topic/Delete/5
        public ActionResult DeleteTopic(long id)
        {
            TopicFactory EditTopic = new TopicFactory();
            TopicEntity topic = new TopicEntity();
            topic = EditTopic.GetTopicById(id);
            return View(topic);
        }

        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult DeleteTopic(long id, FormCollection collection)
        {
            try
            {
                TopicFactory DeleteTopic = new TopicFactory();
                TopicEntity Topic = new TopicEntity();
                Topic = DeleteTopic.GetTopicById(id);

                DataLayer.tblTopic NewTopic = new DataLayer.tblTopic();
                NewTopic.TopicId = id;
                NewTopic.ChannelId = Topic.ChannelId;
                NewTopic.TopicName = Topic.TopicName;
                NewTopic.CreatedDate = Topic.CreatedDate;
                NewTopic.CreatedBy = Topic.CreatedBy;
                NewTopic.UpdatedDate = DateTime.Now;
                NewTopic.UpdatedBy = null;
                NewTopic.IsActive = false; // IsActive will be false in delete record

                DeleteTopic.SaveTopic(NewTopic);

                return RedirectToAction("Topic");
            }
            catch
            {
                return View();
            }
        }
    }
}
