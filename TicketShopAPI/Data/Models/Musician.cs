using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopAPI.Data.Models
{
    public class Musician
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public int? MusicGroupId { get; set; }
        public MusicGroup Group { get; set; }
    }
}
