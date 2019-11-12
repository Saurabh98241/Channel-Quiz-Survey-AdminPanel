using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class QuestionOptionMappingEntity : BaseEntity
    {
        public long OptionId { get; set; }
        public long QuestionId { get; set; }
        public string QuestionOptionText { get; set; }
        public bool IsTrue { get; set; }
        public string Question { get; set; }

    }
}
