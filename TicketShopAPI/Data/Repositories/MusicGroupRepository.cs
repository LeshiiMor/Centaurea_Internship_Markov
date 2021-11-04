using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Interfaces;
using TicketShopAPI.Data.Models;

namespace TicketShopAPI.Data.Repositories
{
    public class MusicGroupRepository : IMusicGroupRepository
    {
        private readonly ContextDB _context;
        public MusicGroupRepository(ContextDB context)
        {
            _context = context;
        }
        public bool Create(MusicGroup group)
        {
            _context.MusicGroups.Add(group);
            return (_context.SaveChanges() > 0);
        }

        public bool Delete(MusicGroup group)
        {
            _context.MusicGroups.Remove(group);
            return (_context.SaveChanges() > 0);
        }

        public MusicGroup Get(int id)
        {
            return (_context.MusicGroups.Find(id));
        }

        public MusicGroup Get(Musician musician)
        {
            return (_context.MusicGroups.FirstOrDefault(p=>p.Id == musician.MusicGroupId));
        }

        public IEnumerable<MusicGroup> GetAll()
        {
            return _context.MusicGroups.Include(p=>p.Musicians);
        }

        public IEnumerable<Musician> GetMusicianFromGroup(MusicGroup group)
        {
            return (_context.Musicians.Where(p=>p.MusicGroupId == group.Id));
        }

        public bool Update(MusicGroup group)
        {
            _context.MusicGroups.Update(group);
            return (_context.SaveChanges() > 0);
        }
    }
}
