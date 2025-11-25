using DAL.Produtos;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace TP04.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosApiController : ControllerBase
    {
        private readonly IRepository<Produto> _repo;

        public ProdutosApiController(IRepository<Produto> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.All.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _repo.Find(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        // POST: api/ProdutosApi
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _repo.Incluir(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id) return BadRequest();

            _repo.Alterar(produto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _repo.Find(id);
            if (produto == null) return NotFound();

            _repo.Excluir(produto);
            return NoContent();
        }
    }
}