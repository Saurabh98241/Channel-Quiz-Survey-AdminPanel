using BusinessLogic.EntityClass;
using BusinessLogic.FactoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerveAdminPanel.Controllers
{
    public class ChannelController : Controller
    {
        // GET: Channel
        public ActionResult Channel()
        {
            ChannelFactory UF = new ChannelFactory();
            List<ChannelEntity> ChannelList = UF.GetChannel().ToList();
            return View(ChannelList);
        }

        // GET: Channel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Channel/Create
        public ActionResult CreateChannel()
        {
            return View();
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult CreateChannel(ChannelEntity Channel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ValidationFactory VF = new ValidationFactory();
                    ChannelFactory AddChannel = new ChannelFactory();
                    DataLayer.tblChannel NewChannel = new DataLayer.tblChannel();
                    string Message = VF.ChannelValidity(Channel.ChannelName, null);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("ChannelName", Message);
                        return View(Channel);
                    }
                    else
                    {
                        NewChannel.ChannelName = Channel.ChannelName;
                        NewChannel.CreatedDate = DateTime.Now;
                        NewChannel.CreatedBy = null;
                        NewChannel.UpdatedDate = null;
                        NewChannel.UpdatedBy = null;
                        NewChannel.IsActive = true;
                        AddChannel.SaveChannel(NewChannel);
                        return RedirectToAction("Channel");
                    }
                }
                else
                {
                    return View(Channel);
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: Channel/Edit/5
        public ActionResult EditChannel(int id)
        {
            ChannelFactory EditChannel = new ChannelFactory();
            ChannelEntity channel = new ChannelEntity();
            channel = EditChannel.GetChannelById(id);
            return View(channel);
        }

        // POST: Channel/Edit/5
        [HttpPost]
        public ActionResult EditChannel(int id, ChannelEntity Channel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ChannelFactory EditChannel = new ChannelFactory();
                    DataLayer.tblChannel NewChannel = new DataLayer.tblChannel();

                    ValidationFactory VF = new ValidationFactory();
                    string Message = VF.ChannelValidity(Channel.ChannelName, id);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("ChannelName", Message);
                        return View(Channel);
                    }
                    else
                    {
                        NewChannel.ChannelId = id;
                        NewChannel.ChannelName = Channel.ChannelName;
                        NewChannel.CreatedDate = Channel.CreatedDate;
                        NewChannel.CreatedBy = null;
                        NewChannel.UpdatedDate = DateTime.Now;
                        NewChannel.UpdatedBy = null;
                        NewChannel.IsActive = Channel.IsActive;
                        EditChannel.SaveChannel(NewChannel);
                        return RedirectToAction("Channel");
                    }

                  
                }
                else
                {
                    return View(Channel);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Channel/Delete/5
        [HttpGet]
        public ActionResult DeleteChannel(int id)
        {
            ChannelFactory EditChannel = new ChannelFactory();
            ChannelEntity channel = new ChannelEntity();
            channel = EditChannel.GetChannelById(id);
            return View(channel);
        }

        // POST: Channel/Delete/5
        [HttpPost]
        public ActionResult DeleteChannel(long id)
        {
            try
            {
                ChannelFactory DeleteChannel = new ChannelFactory();
                ChannelEntity Channel = new ChannelEntity();
                Channel = DeleteChannel.GetChannelById(id);

                DataLayer.tblChannel NewChannel = new DataLayer.tblChannel();
                NewChannel.ChannelId = id;
               
                NewChannel.ChannelName = Channel.ChannelName;
                NewChannel.CreatedDate = Channel.CreatedDate;
                NewChannel.CreatedBy = Channel.CreatedBy;
                NewChannel.UpdatedDate = DateTime.Now;
                NewChannel.UpdatedBy = null;
                NewChannel.IsActive = false; // IsActive will be false in delete record

                DeleteChannel.SaveChannel(NewChannel);

                return RedirectToAction("Channel");
            }
            catch
            {
                return View();
            }
        }
    }
}
