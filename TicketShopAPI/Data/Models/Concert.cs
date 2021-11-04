using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopAPI.Data.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public int AmountTickets { get; set; } = 0;
        public DateTime DateEvent { get; set; }
        public string Place { get; set; }
    }
}
