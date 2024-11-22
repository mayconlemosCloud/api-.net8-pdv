using Aplicacao.DTO;
using Aplicacao.Interfaces;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Venda>>> GetAll()
        {
            var vendas = await _vendaService.GetAllAsync();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetById(int id)
        {
            var venda = await _vendaService.GetByIdAsync(id);
            if (venda == null)
                return NotFound();
            return Ok(venda);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] VendaDTO vendaDTO)
        {
            await _vendaService.AddAsync(vendaDTO);
            return CreatedAtAction(nameof(GetById), new { id = vendaDTO.Id }, vendaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] VendaDTO vendaDTO)
        {
            if (id != vendaDTO.Id)
                return BadRequest();

            await _vendaService.UpdateAsync(vendaDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _vendaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
