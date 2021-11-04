using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Models;

namespace TicketShopAPI.Data.Interfaces
{
    interface IMusicGroupRepository
    {
        bool Create(MusicGroup group);
        bool Delete(MusicGroup group);
        bool Update(MusicGroup group);
        MusicGroup Get(int id);
        MusicGroup Get(Musician musician);
        IEnumerable<MusicGroup> GetAll();
        IEnumerable<Musician> GetMusicianFromGroup(MusicGroup group);
    }
}
