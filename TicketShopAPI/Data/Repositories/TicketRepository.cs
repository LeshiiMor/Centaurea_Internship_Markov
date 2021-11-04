using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Interfaces;
using TicketShopAPI.Data.Models;

namespace TicketShopAPI.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ContextDB _context;
        public TicketRepository(ContextDB context)
        {
            _context = context;
        }
        public bool Create(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            return (_context.SaveChanges()>0);
        }

        public bool Delete(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            return (_context.SaveChanges() > 0);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _context.Tickets;
        }

        public IEnumerable<Ticket> GetAllByConcert(Concert concert)
        {
            return _context.Tickets.Where(p=>p.ConcertId == concert.Id);
        }

        public IEnumerable<Ticket> GetAllByConcert(Concert concert, bool IsBooking)
        {

            return _context.Tickets.Where(p => p.ConcertId == concert.Id && p.IsBooking == IsBooking);
        }

        public bool Update(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            return (_context.SaveChanges() > 0);
        }
    }
}
