using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BusinessLogic.EntityClass
{
   public class UserEntity
    {
        public long UserId { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage ="please enter first name")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "please enter Last name")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "please enter User name")]
        [MaxLength(50)]
        public string UserName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "please enter Email")]
        [MaxLength(50)]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "please enter Contact Number")]
        [MaxLength(10)]
        [MinLength(10)]
        public string ContactNumber { get; set; }
        [DisplayName("Address")]
        [Required(ErrorMessage = "please enter Address")]
        [MaxLength(1000)]
        public string Address { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
