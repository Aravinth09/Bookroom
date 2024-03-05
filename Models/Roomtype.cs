using System.Collections.Generic;

namespace Bookroom.Models
{
public class Roomtype

{

    public int RoomtypeId { get; set; }

    public string Size { get; set; }

    public string Type { get; set; }


    public decimal Roomrent { get; set; }

    public string AvailabilityStatus { get; set; }

    public List<Rent> Rents { get; set; }

}
}