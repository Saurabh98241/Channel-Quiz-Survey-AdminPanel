using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BusinessLogic.EntityClass
{
   public class TopicEntity : BaseEntity
    {
        public long TopicId { get; set; }
        [DisplayName("Channel")]
        [Required(ErrorMessage ="Please select Channel")]
        public long ChannelId { get; set; }
        [DisplayName("Topic Name")]
        [Required(ErrorMessage = "Please enter topic name")]
        [MaxLength(50)]
        public string TopicName { get; set; }
        [DisplayName("Channel Name")]
        public string ChannelName { get; set; }
    }
}
