using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Models;

namespace TicketShopAPI.Data.Interfaces
{
    public interface IMusicianRepository
    {
        bool Create(Musician musician);
        bool Delete(Musician musician);
        bool Update(Musician musician);
        Musician Get(int id);
        IEnumerable<Musician> GetAll();
        IEnumerable<Musician> GetByGroup(MusicGroup group);
        MusicGroup GetGroup(Musician musician);
    }
}
