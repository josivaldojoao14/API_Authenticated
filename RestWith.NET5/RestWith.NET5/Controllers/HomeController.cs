using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWith.NET5.Model;
using RestWith.NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWith.NET5.Controllers
{
    public class HomeController : Controller
    {
        private readonly MySQLContext _context;
        public HomeController(MySQLContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Cliente model)
        {
            // Recupera o usuário
            var user = _context.Clientes.First<Cliente>(c => c.Email == model.Email && c.senha == model.senha);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.senha = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated()
        {
            var user = User.Identity;
            return string.Format("Autenticado - {0}", User.Identity.Name);
        }

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,admin")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public string Admin() => "Administrador";
    }
}
