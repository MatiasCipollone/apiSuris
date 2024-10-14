namespace ApiSuris.Models
{
    public class Pedido
    {
        public int VendedorId { get; set; }
        public required List<string> ArticuloCodigos { get; set; }
    }
}
