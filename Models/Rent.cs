using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookroom.Models
{
    public class Rent
    {
        public string PriceId { get; set; }
        public int RentalRatePerDay  { get; set; }

        public int Discounts  { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Roomtype? Room {get;set;}
    }
}