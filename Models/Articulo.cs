namespace ApiSuris.Models
{
    public class Articulo
    {
        public required string Codigo { get; set; }
        public required string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Deposito { get; set; }
    }
}
