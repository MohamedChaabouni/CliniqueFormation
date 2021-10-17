using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CliniqueFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezVousController : ControllerBase
    {
        private readonly IRendezVousService rendezVousService;

        public RendezVousController(IRendezVousService rendezVousService)
        {
            this.rendezVousService = rendezVousService;
        }
        [HttpGet]
        public IActionResult List()
        {
            return Ok(rendezVousService.GetList());
        }
    }
}
