using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Models
{
    public class Customer
    {
        [Required]
        public Guid CustomerId { get;set; }
        [Required]
        public string CustomerNumber { get; set; }

        public string CustomerName { get;set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [Required]
        public DateTime CreatedDate {  get; set; }
        [Required]
        public DateTime UpdatedDate { get; set;}
    }
}
