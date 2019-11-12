using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class BlogEntity : BaseEntity
    {
        public long BlogId { get; set; }
        [Required(ErrorMessage = "Please Select Topic")]
        public long TopicId { get; set; }
        [DisplayName("Topic Name")]
        public string TopicName { get; set; }
        [DisplayName("Blog Name")]
        [Required(ErrorMessage = "Please enter blog name")]
        [MaxLength(50)]
        public string BlogName { get; set; }
        [DisplayName("Blog Heading")]
        [Required(ErrorMessage = "Please enter Blog heading")]
        [MaxLength(50)]
        public string BlogHeading { get; set; }
        
    }
}
