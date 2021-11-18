using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Models;
using TicketShopAPI.Models.Dtos;

namespace TicketShopAPI.Profiles
{
    public class MusiciansProfile:Profile
    {
        public MusiciansProfile()
        {
            // source --> target
            CreateMap<Musician, MusicianDto>().ForMember("NameGroup", opt => opt.MapFrom(n=>n.Group.Name));
            CreateMap<MusicianDto, Musician>();
        }
    }
}
