using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopAPI.Data.Models.TypeConcerts
{
    [Table("OpenAirTypes")]
    public class OpenAirType:BaseTypeConcert
    {
        public string Headliner { get; set; }
    }
}
