using Aplicacao.Interfaces;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItensVendaController: ControllerBase
    {
        private readonly IItemVendaService _itemVendaService;

        public ItensVendaController(IItemVendaService itemVendaService)
        {
            _itemVendaService = itemVendaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemVenda>>> Get()
        {
            var clientes = await _itemVendaService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _itemVendaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
