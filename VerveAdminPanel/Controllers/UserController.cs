using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.EntityClass;
using BusinessLogic.FactoryClass;

namespace VerveAdminPanel.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public ActionResult Index()
        {
            UserFactory UF = new UserFactory();
            List<UserEntity> UserList = UF.GetUser().ToList();
            return View(UserList);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserEntity User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ValidationFactory VF = new ValidationFactory();
                    UserFactory AddUser = new UserFactory();
                    DataLayer.tblUser NewUser = new DataLayer.tblUser();
                    string Message = VF.UserValidity(User.UserName, null);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("UserName", Message);
                        return View(User);
                    }
                    else
                    {
                        NewUser.FirstName = User.FirstName;
                        NewUser.LastName = User.LastName;
                        NewUser.UserName = User.UserName;
                        NewUser.Email = User.Email;
                        NewUser.ContactNumber = User.ContactNumber;
                        NewUser.Address = User.Address;
                        NewUser.ProfilePic = User.ProfilePic;
                        NewUser.CreatedDate = DateTime.Now;
                        NewUser.CreatedBy = null;
                        NewUser.UpdatedDate = null;
                        NewUser.UpdatedBy = null;
                        NewUser.IsActive = true;
                        AddUser.SaveUser(NewUser);
                        return RedirectToAction("Index");
                    }


                }
                else
                {

                    return View(User);
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: User/Edit/5
        public ActionResult Edit(long id)
        {
            UserFactory EditUser = new UserFactory();
            UserEntity user = new UserEntity();
            user = EditUser.GetUserById(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, UserEntity User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserFactory EditUser = new UserFactory();
                    DataLayer.tblUser NewUser = new DataLayer.tblUser();
                    ValidationFactory VF = new ValidationFactory();
                    string Message = VF.UserValidity(User.UserName, id);
                    if (Message != "Success")
                    {
                        ModelState.AddModelError("UserName", Message);
                        return View(User);
                    }
                    else
                    {
                        NewUser.UserId = id;
                        NewUser.FirstName = User.FirstName;
                        NewUser.LastName = User.LastName;
                        NewUser.UserName = User.UserName;
                        NewUser.Email = User.Email;
                        NewUser.ContactNumber = User.ContactNumber;
                        NewUser.Address = User.Address;
                        NewUser.ProfilePic = User.ProfilePic;
                        NewUser.CreatedDate = User.CreatedDate;
                        NewUser.CreatedBy = null;
                        NewUser.UpdatedDate = DateTime.Now;
                        NewUser.UpdatedBy = null;
                        NewUser.IsActive = User.IsActive;
                        EditUser.SaveUser(NewUser);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View(User);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            UserFactory EditUser = new UserFactory();
            UserEntity user = new UserEntity();
            user = EditUser.GetUserById(id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                UserFactory DeleteUser = new UserFactory();
                UserEntity User = new UserEntity();
                User = DeleteUser.GetUserById(id);

                DataLayer.tblUser NewUser = new DataLayer.tblUser();
                NewUser.UserId = id;
                NewUser.FirstName = User.FirstName;
                NewUser.LastName = User.LastName;
                NewUser.UserName = User.UserName;
                NewUser.Email = User.Email;
                NewUser.ContactNumber = User.ContactNumber;
                NewUser.Address = User.Address;
                NewUser.ProfilePic = User.ProfilePic;
                NewUser.CreatedDate = User.CreatedDate;
                NewUser.CreatedBy = User.CreatedBy;
                NewUser.UpdatedDate = DateTime.Now;
                NewUser.UpdatedBy = null;
                NewUser.IsActive = false; // IsActive will be false in delete record

                DeleteUser.SaveUser(NewUser);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
