using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Models;
using TicketShopAPI.Data.Models.TypeConcerts;

namespace TicketShopAPI.Data
{
    public class ContextDB:DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicGroup> MusicGroups { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<ClassicType> ClassicTypes { get; set; }
        public DbSet<OpenAirType> OpenAirTypes { get; set; }
        public DbSet<PartyType> PartyTypes { get; set; }
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
