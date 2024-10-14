using ApiSuris.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ApiSuris.Services
{
    public class DataService
    {
        private readonly string _pathArticulos = "Data/articulos.json";
        private readonly string _pathVendedores = "Data/vendedores.json";

        public List<Articulo> GetArticulos()
        {
            var json = File.ReadAllText(_pathArticulos);
            var data = JsonConvert.DeserializeObject<Dictionary<string, List<Articulo>>>(json);
            return data["articulos"]
                .Where(a => EsArticuloValido(a))
                .ToList();
        }

        public List<Vendedor> GetVendedores()
        {
            var json = File.ReadAllText(_pathVendedores);
            var data = JsonConvert.DeserializeObject<Dictionary<string, List<Vendedor>>>(json);
            return data["vendedores"];
        }

        private bool EsArticuloValido(Articulo articulo)
        {
            return articulo.Deposito == 1 &&
                   articulo.Precio > 0 &&
                   EsDescripcionValida(articulo.Descripcion);
        }

        // Validación para la descripción: permite solo letras, números y espacios
        private static bool EsDescripcionValida(string descripcion)
        {
            // Expresión regular para permitir solo letras, números y espacios
            return Regex.IsMatch(descripcion, @"^[a-zA-Z0-9\s]+$");
        }
    }
}
