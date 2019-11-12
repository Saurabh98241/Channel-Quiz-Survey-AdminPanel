using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class SurveyAnswerTypeEntity
    {
        public int AnsTypeId { get; set; }
        public string AnswerType { get; set; }
        public bool IsActive { get; set; }

    }
}
