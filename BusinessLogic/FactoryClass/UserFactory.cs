using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.EntityClass;
using DataLayer;
using System.Data.Entity;

namespace BusinessLogic.FactoryClass
{
   public class UserFactory : BaseClass
    {
        public List<UserEntity> GetUser()
        {
            List<UserEntity> ListUser = new List<UserEntity>();
            ListUser = db.tblUsers.OrderByDescending(x => x.UserId).Where(x => x.IsActive == true).Select(x => new UserEntity() {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Email = x.Email,
                ContactNumber= x.ContactNumber,
                Address= x.Address,

            }).ToList();
            return ListUser;
        }

        public void SaveUser(tblUser User) {
            if (User.UserId == 0)
            {
                db.tblUsers.Add(User);
            }
            else
            {
                db.Entry(User).State = EntityState.Modified;       
            }
                db.SaveChanges();
        }
        public UserEntity GetUserById(long Id)
        {
            UserEntity User = new UserEntity();
            User = db.tblUsers.Where(x => x.UserId == Id).Select(x => new UserEntity() {
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Email = x.Email,
                ContactNumber = x.ContactNumber,
                Address = x.Address,
                ProfilePic=x.ProfilePic,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                IsActive = x.IsActive
            }).FirstOrDefault();
            return User;
        }

       
    }
}
