using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using PROVA02.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PROVA02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosApiController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;

        public UsuariosApiController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        // 1. LISTAR TODOS (GET)
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna apenas dados seguros (sem a senha hash)
            var users = _userManager.Users.Select(u => new
            {
                u.Id,
                u.Nome,
                u.UserName,
                u.Status,
                u.Email
            }).ToList();

            return Ok(users);
        }

        // 2. BUSCAR UM POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(new { user.Id, user.Nome, user.UserName, user.Status });
        }

        // 3. CRIAR (POST) - Requisito da Prova
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new Usuario
            {
                UserName = model.Login,
                Nome = model.Nome,
                Status = true,
                Email = "api_" + model.Login + "@email.com" // Email fake para validar
            };

            // O Identity cria e criptografa a senha automaticamente
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Retorna 201 Created
                return CreatedAtAction(nameof(Get), new { id = user.Id }, new { user.Id, user.Nome });
            }

            return BadRequest(result.Errors);
        }

        // 4. EDITAR (PUT) - Alterar Nome ou Status
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UsuarioApi model)
        {
            // UsuarioApi é aquela classe simples que criamos no Model lá no começo
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            // Atualiza os campos
            user.Nome = model.Nome;
            user.Status = model.Status;

            // O Identity salva no banco
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Ok(new { message = "Usuário atualizado com sucesso" });

            return BadRequest(result.Errors);
        }

        // (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded) return NoContent();

            return BadRequest(result.Errors);
        }
    }
}