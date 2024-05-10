using Vendagas.API.Application.Services.Empresa;
using Vendagas.API.Application.Services.Token;
using Vendagas.API.Application.Services.User;
using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Cliente;
using Vendagas.API.ORM.Repository;

namespace Vendagas.API.Application.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly BaseRepository<ClienteModel> _clienteRepository;
        private readonly IEmpresaService _empresaService;

        public ClienteService(BaseRepository<ClienteModel> clienteRepository, IEmpresaService empresaService)
        {
            _clienteRepository = clienteRepository;
            _empresaService = empresaService;            
        }
        public ClienteModel CreateCliente(int empresaId, ClienteRequest clienteRequest)
        {            
            if (clienteRequest == null)
            {
                throw new ArgumentNullException(nameof(clienteRequest));
            }
            var empresa = _empresaService.GetEmpresaById(empresaId);

            if (empresa == null)
            {
                throw new KeyNotFoundException($"Empresa com o ID {empresaId} não encontrada");
            }
            var newCliente = new ClienteModel
            {
                ClienteName = clienteRequest.ClienteName,
                Telefone = clienteRequest.Telefone,
                Email = clienteRequest.Email,
                EmpresaId = empresaId,
                Empresa = empresa,
            };

            var createdClient = _clienteRepository.Add(newCliente);
            _clienteRepository.SaveChanges();
            return createdClient;
        }
    }
}
