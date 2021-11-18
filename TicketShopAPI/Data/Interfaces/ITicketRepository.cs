using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Models;

namespace TicketShopAPI.Data.Interfaces
{
    public interface ITicketRepository
    {
        bool Create(Ticket ticket);
        bool Delete(Ticket ticket);
        bool Update(Ticket ticket);
        IEnumerable<Ticket> GetAll();
        IEnumerable<Ticket> GetAllByConcert(Concert concert);
        IEnumerable<Ticket> GetAllByConcert(Concert concert,bool IsBooking);
    }
}
