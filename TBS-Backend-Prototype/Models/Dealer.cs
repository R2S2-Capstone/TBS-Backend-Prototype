using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBS_Backend_Prototype.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLasttName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PaymentEmail { get; set; }
        public string CompanyName { get; set; }
        public Address Address { get; set; }
    }
}
