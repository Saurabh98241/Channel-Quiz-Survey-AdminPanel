using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityClass
{
   public class SurveyEntity :BaseEntity
    {

        public long SurveyId { get; set; }
        [Required(ErrorMessage = "Please Select answer type")]
        public int AnsTypeId { get; set; }
        [DisplayName("Survey Name")]
        [Required(ErrorMessage = "Please enter survey name")]
        public string SurveyName { get; set; }
        [DisplayName("Survey Description")]
        [Required(ErrorMessage = "Please enter survey description")]
        public string SurveyDescription { get; set; }
        [DisplayName("Completion Text")]
        [Required(ErrorMessage = "Please enter Completion text")]
        public string CompletionText { get; set; }
        public bool IsNeverExpire { get; set; }
        [DisplayName("Expiry Date")]
        public Nullable<System.DateTime> ExpiryDate { get; set; }
   

        public int AnswerTypeId { get; set; }
        [DisplayName("Answer Type")]
        public string AnswerType { get; set; }

    }
}
