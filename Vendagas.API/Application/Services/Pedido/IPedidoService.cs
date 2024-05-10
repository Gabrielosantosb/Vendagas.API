using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Cliente;
using Vendagas.API.ORM.Model.Pedido;

namespace Vendagas.API.Application.Services.Pedido
{
    public interface IPedidoService
    {
        IEnumerable<PedidoModel> GetAllPedidos();
        PedidoModel GetPedidoById(int id);
        PedidoModel CreatePedido(int empresaId, PedidoRequestModel requestModel);
        
    }
}
