using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopAPI.Data.Models.TypeConcerts
{
    [Table("ClassicTypes")]
    public class ClassicType:BaseTypeConcert
    {
        public string TypeVoice { get; set; }
        public string NameComposer { get; set; }
    }
}
