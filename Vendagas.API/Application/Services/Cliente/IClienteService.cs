using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Cliente;

namespace Vendagas.API.Application.Services.Cliente
{
    public interface IClienteService
    {
        ClienteModel CreateCliente(int empresaId, ClienteRequest clienteRequest);
    }
}
