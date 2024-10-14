using ApiSuris.Models;
using ApiSuris.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiSuris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController(DataService dataService) : ControllerBase
    {
        private readonly DataService _dataService = dataService;

        [HttpGet]
        public ActionResult<List<Vendedor>> GetVendedores()
        {
            var vendedores = _dataService.GetVendedores();
            return Ok(vendedores);
        }
    }
}
