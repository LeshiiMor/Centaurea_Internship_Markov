using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Interfaces;
using TicketShopAPI.Data.Models;
using TicketShopAPI.Data.Repositories;
using TicketShopAPI.Models.Dtos;

namespace TicketShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        public readonly IMusicianRepository _musRepo;
        public readonly IMusicGroupRepository _groupRepo;
        public readonly IMapper _mapper;
        public MusicianController(IMusicianRepository musRepo, IMapper mapper, IMusicGroupRepository groupRepo)
        {
            _musRepo = musRepo;
            _mapper = mapper;
            _groupRepo = groupRepo;
        }

        [HttpPost("create")]
        [Authorize(Roles = "admin")]
        public IActionResult Create(MusicianDto newMusician)
        {
            Musician musician = _mapper.Map<Musician>(newMusician);
            if (musician.MusicGroupId == 0) musician.MusicGroupId = null;
            if (_musRepo.Create(musician)) return Ok(newMusician);
            else return BadRequest();
        }

        [HttpGet("getall")]
        [Authorize]
        public IActionResult GetAll(string? stringSearch, int idGroup)
        {
            var musicians = _musRepo.GetAll();
            if(String.IsNullOrEmpty(stringSearch) && idGroup == 0)
            {
                var musiciansDto = _mapper.Map<IEnumerable<MusicianDto>>(musicians);
                return Ok(musiciansDto);
            }
            else if(idGroup == 0 && !String.IsNullOrEmpty(stringSearch))
            {
                var musicianDto = _mapper.Map<IEnumerable<MusicianDto>>(musicians.Where(p=>p.Name.Contains(stringSearch) || p.Surname.Contains(stringSearch)|| p.Nickname.Contains(stringSearch)));
                return Ok(musicianDto);
            }
            else if(idGroup !=0 && String.IsNullOrEmpty(stringSearch))
            {
                MusicGroup group = _groupRepo.Get(idGroup);
                var musicianDtos = _mapper.Map<IEnumerable<MusicianDto>>(_musRepo.GetByGroup(group));
                return Ok(musicianDtos);
            }
            return BadRequest();
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            Musician musician = _musRepo.Get(id);
            if (musician == null) return NotFound();
            else return Ok(_mapper.Map<MusicianDto>(musician));
        }

        [HttpPost("delete/{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            Musician musician = _musRepo.Get(id);
            if (musician == null) return NotFound();
            if (_musRepo.Delete(musician)) return Ok();
            else return BadRequest();
        }

        [HttpPost("edit")]
        [Authorize]
        public IActionResult Edit(MusicianDto musicianDto)
        {
            Musician musician = _mapper.Map<Musician>(musicianDto);
            if (_musRepo.Update(musician)) return Ok();
            else return BadRequest();
        }
    }
}
