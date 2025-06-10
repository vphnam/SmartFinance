using SF.Application.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Application.Contracts.Customers.Dto
{
    public class CustomerDto : DtoBase
    {
        [Required]
        [MaxLength(10)]
        public string? CustomerNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string? CustomerName { get; set; }
        [Required]
        [MaxLength (50)]
        public string? CustomerEmail { get; set; }
        [Required]
        [MaxLength (50)]
        public string? CustomerAddress { get; set; }

        public CustomerDto(string? customerNumber, string? customerName, string? customerEmail, string? customerAddress)
        {
            CustomerNumber = customerNumber;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerAddress = customerAddress;
        }
    }
}
