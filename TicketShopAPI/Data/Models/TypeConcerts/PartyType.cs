using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopAPI.Data.Models.TypeConcerts
{
    [Table("PartyTypes")]
    public class PartyType:BaseTypeConcert
    {
        public int AgeRage { get; set; }
        public string Topic { get; set; }
        public string Opportunities { get; set; }
    }
}
