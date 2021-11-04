using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Interfaces;
using TicketShopAPI.Data.Models;

namespace TicketShopAPI.Data.Repositories
{
    public class MusicianRepository : IMusicianRepository
    {
        private readonly ContextDB _context;
        public MusicianRepository(ContextDB context)
        {
            _context = context;
        }
        public bool Create(Musician musician)
        {
            _context.Musicians.Add(musician);
            return (_context.SaveChanges() > 0);
        }

        public bool Delete(Musician musician)
        {
            _context.Musicians.Remove(musician);
            return (_context.SaveChanges() > 0);
        }

        public Musician Get(int id)
        {
            return (_context.Musicians.Find(id));
        }

        public IEnumerable<Musician> GetAll()
        {
            return _context.Musicians.Include(p=>p.Group);
        }

        public MusicGroup GetGroup(Musician musician)
        {
            return (_context.MusicGroups.FirstOrDefault(p => p.Id == musician.MusicGroupId));
        }

        public bool Update(Musician musician)
        {
            _context.Musicians.Update(musician);
            return (_context.SaveChanges() > 0);
        }
    }
}
