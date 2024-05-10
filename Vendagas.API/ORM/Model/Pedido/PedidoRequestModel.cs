namespace Vendagas.API.ORM.Model.Pedido
{
    public class PedidoRequestModel
    {
        public int PedidoId { get; set; }
        public int Numero { get; set; }
        public string Observacao { get; set; }

        public string Cliente { get; set; }
        public DateTime Data { get; set; }

    }
}
