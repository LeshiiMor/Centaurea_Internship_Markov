using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopAPI.Data.Interfaces;
using TicketShopAPI.Data.Repositories;

namespace TicketShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicGroupController : ControllerBase
    {
        private readonly IMusicGroupRepository _groupRepos;
        public MusicGroupController(IMusicGroupRepository groupRepos)
        {
            _groupRepos = groupRepos;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var groups = _groupRepos.GetAll();
            return Ok(groups);
        }
    }
}
