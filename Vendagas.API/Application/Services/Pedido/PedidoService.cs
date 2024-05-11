using Microsoft.EntityFrameworkCore;
using Vendagas.API.ORM.Context;
using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Pedido;
using Vendagas.API.ORM.Repository;

namespace Vendagas.API.Application.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly BaseRepository<PedidoModel> _pedidoRepository;
        private readonly VendagasContext _context;
        public PedidoService(BaseRepository<PedidoModel> pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public PedidoModel CreatePedido(int empresaId, PedidoRequestModel requestModel)
        {
            if(requestModel == null)
            {
                throw new ArgumentNullException(nameof(requestModel));
            }
            var newPedido = new PedidoModel
            {
                Data = DateTime.Now,
                Cliente = requestModel.Cliente,
                EmpresaId = empresaId,
                Numero = GenerateRandomNumber(),
                Observacao = requestModel.Observacao,                
            };
            var createdPedido = _pedidoRepository.Add(newPedido);
            _pedidoRepository.SaveChanges();
            return createdPedido;
        }

        public IEnumerable<PedidoModel> GetAllPedidos()
        {
            return _pedidoRepository._context.Pedido.Include(p =>p.Empresa).ToList();                
            //return _pedidoRepository.GetAll();
        }

        public PedidoModel GetPedidoById(int id)
        {
            var pedido = _pedidoRepository.GetAll().FirstOrDefault(p => p.PedidoId == id);
            return pedido;
        }
        private int GenerateRandomNumber()
        {            
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999);
            return randomNumber;
        }
    }
}
