using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class ChannelEntity: BaseEntity
    {
        public long ChannelId { get; set; }
        [DisplayName("Channel Name")]
        [MaxLength(50)]
        [Required(ErrorMessage ="Please enter channel name")]
        public string ChannelName { get; set; }
    }
}
