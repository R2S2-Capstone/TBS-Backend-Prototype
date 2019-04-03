using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TBS_Backend_Prototype.Models
{
    public class Move
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime PickUpDate { get; set; }
        [Required]
        public DateTime DropOffDate { get; set; }
        [Required]
        public bool BiddingComplete {get; set; }
        [Required]
        public bool TransportComplete {get; set; }
        [Required]
        public bool DealerAcceptedComplete { get; set; }
        [Required]
        public string UserCompanyName { get; set; }
        [Required]
        public Dealer Dealer{ get; set; }
        [Required]
        public Vehicle Vehicle { get; set; }
    }
}
