using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookroom.Models
{
    public class Bookingorder
    {
        public int OrderId { get; set; }
        public string RentalStartDate { get; set; }

        public string RentalEndDate { get; set; }

        public string Price { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer{get;set;}

        [ForeignKey("Roomtype")]
        public int RoomId { get; set; }
        public Roomtype ? Roomtype {get;set;}
       
      
    }
}