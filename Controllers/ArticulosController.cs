using ApiSuris.Models;
using ApiSuris.Services;
using Microsoft.AspNetCore.Mvc;


namespace ApiSuris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController(DataService dataService) : ControllerBase
    {
        private readonly DataService _dataService = dataService;

        [HttpGet]
        public ActionResult<List<Articulo>> GetArticulos()
        {
            var articulos = _dataService.GetArticulos();
            return Ok(articulos);
        }
    }
}
