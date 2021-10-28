using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopAPI.Data.Models
{
    public class MusicGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortInfo { get; set; }
        IEnumerable<Musician> Musicians { get; set; }
    }
}
