using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWith.NET5.Model;
using RestWith.NET5.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RestWith.NET5.Controllers
{
    [ApiVersion("1")] // Indica qual a versão da API
    [ApiController]
    [Route("api/[controller]/v{version:ApiVersion}")] // Indica qual o path global da API, juntamente com o versionamento que fizemos acima
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private IClienteBusiness _clienteBusiness;

        public ClienteController(ILogger<ClienteController> logger, IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteBusiness.FindAll());
        } 
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var cliente = _clienteBusiness.FindByID(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Create(cliente));
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Update(cliente));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _clienteBusiness.Delete(id);
            return NoContent();
        }
    }
}
