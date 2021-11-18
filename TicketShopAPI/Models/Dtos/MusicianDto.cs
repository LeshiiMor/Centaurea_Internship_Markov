using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopAPI.Models.Dtos
{
    public class MusicianDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public int MusicGroupId { get; set; }
        public string NameGroup { get; set; }
    }
}
