using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopAPI.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public bool IsBooking { get; set; } = false;
        public double Price { get; set; }
    }
}
