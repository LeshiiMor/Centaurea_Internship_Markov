using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Models;

namespace TicketShopAPI.Data.Interfaces
{
    public interface IConcertRepository
    {
        bool Create(Concert concert);
        bool Delete(Concert concert);
        bool Update(Concert concert);
        IEnumerable<Concert> GetAll();
        IEnumerable<Concert> GetByDate(DateTime date);
        IEnumerable<Concert> GetByDate(DateTime fDate,DateTime sDate);
        Concert Get(int id);
        Concert GetByPlace(string place);
    }
}
