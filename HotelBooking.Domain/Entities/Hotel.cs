using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
    }
}
