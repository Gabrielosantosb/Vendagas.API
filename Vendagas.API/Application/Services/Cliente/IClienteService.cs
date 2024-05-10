using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Cliente;

namespace Vendagas.API.Application.Services.Cliente
{
    public interface IClienteService
    {
        string GetEmpresaNameById(int empresaId);

        IEnumerable<ClienteModel> GetAllClientes();
        IEnumerable<ClienteModel> GetAllClientesByEmpresa(int empresaId);
        ClienteModel CreateCliente(int empresaId, ClienteRequest clienteRequest);
    }
}
