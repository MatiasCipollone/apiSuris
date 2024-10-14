using ApiSuris.Models;
using ApiSuris.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiSuris.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController(DataService dataService) : ControllerBase
    {
        private readonly DataService _dataService = dataService;

        [HttpPost]
        public IActionResult CrearPedido([FromBody] Pedido pedido) 
        {
            var vendedores = _dataService.GetVendedores();
            var vendedorValido = vendedores.Any(v => v.Id == pedido.VendedorId);
            if (!vendedorValido)
            {
                return BadRequest("Vendedor no válido.");
            }

            var articulos = _dataService.GetArticulos();
            var articulosSeleccionados = articulos.Where(a => pedido.ArticuloCodigos.Contains(a.Codigo)).ToList();

            if (articulosSeleccionados.Count == 0)
            {
                return BadRequest("No se seleccionaron artículos válidos.");
            }

            foreach (var articulo in articulosSeleccionados)
            {
                if (articulo.Precio <= 0)
                {
                    return BadRequest($"El artículo {articulo.Codigo} tiene un precio no válido.");
                }

                if (!articulo.Descripcion.All(ch => char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)))
                {
                    return BadRequest($"El artículo {articulo.Codigo} tiene una descripción no válida.");
                }

                if (articulo.Deposito != 1)
                {
                    return BadRequest($"El artículo {articulo.Codigo} no está en el Depósito 1.");
                }
            }

            return Ok("Pedido generado exitosamente.");
        }
    }
}