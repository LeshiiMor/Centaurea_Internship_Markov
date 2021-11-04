using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Interfaces;
using TicketShopAPI.Data.Models;

namespace TicketShopAPI.Data.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly ContextDB _context;
        public ConcertRepository(ContextDB context)
        {
            _context = context;
        }
        public bool Create(Concert concert)
        {
            _context.Concerts.Add(concert);
            return (_context.SaveChanges()>0);
        }

        public bool Delete(Concert concert)
        {

            _context.Concerts.Remove(concert);
            return (_context.SaveChanges() > 0);
        }

        public Concert Get(int id)
        {
            return _context.Concerts.FirstOrDefault(p=>p.Id == id);
        }

        public IEnumerable<Concert> GetAll()
        {
            return _context.Concerts;
        }

        public IEnumerable<Concert> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Concert> GetByDate(DateTime fDate, DateTime sDate)
        {
            throw new NotImplementedException();
        }

        public Concert GetByPlace(string place)
        {
            throw new NotImplementedException();
        }

        public bool Update(Concert concert)
        {

            _context.Concerts.Update(concert);
            return (_context.SaveChanges() > 0);
        }
    }
}
