using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialServiceConsultants.WebAPI.MessageTypes
{
    public class CustomerV1
    {
        [Required]
        public string CompanyName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
    }
}
