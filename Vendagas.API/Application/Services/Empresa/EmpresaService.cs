using System.Runtime.InteropServices;
using Vendagas.API.Application.Services.Token;
using Vendagas.API.Application.Services.User;
using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Empresa;
using Vendagas.API.ORM.Repository;

namespace Vendagas.API.Application.Services.Empresa
{
    public class EmpresaService : IEmpresaService
    {
        private readonly BaseRepository<EmpresaModel> _empresaRepository;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        
        public EmpresaService(BaseRepository<EmpresaModel> empresaRepository, IUserService userService, ITokenService tokenService)
        {
            _empresaRepository = empresaRepository;
            _userService = userService;
            _tokenService = tokenService;
        }


        public int CountAllEmpresas()
        {
            return _empresaRepository.Count();
        }

        public EmpresaModel CreateEmpresa(CreateEmpresaModel empresa)
        {            
            var userId = _tokenService.GetUserId();
            var user = _userService.GetUserById(userId);
            if (empresa == null)
            {
                throw new ArgumentNullException(nameof(empresa));

            }
            var newEmpresa = new EmpresaModel
            {
                NomeFantasia = empresa.NomeFantasia,
                RazaoSocial = empresa.RazaoSocial,
                Cnpj = empresa.Cnpj,
                User = user,
            };

            var createdEmpresa = _empresaRepository.Add(newEmpresa);
            _empresaRepository.SaveChanges();
            return createdEmpresa;
        }

        public EmpresaModel UpdateEmpresa(int id, CreateEmpresaModel updatedEmpresa)
        {
            if (updatedEmpresa == null)
            {
                throw new ArgumentNullException(nameof(updatedEmpresa));
            }

            var existEmpresa = _empresaRepository.GetById(id);

            if (existEmpresa == null)
            {
                throw new KeyNotFoundException($"Empresa com o ID {id} não encontrada");
            }

            existEmpresa.NomeFantasia = updatedEmpresa.NomeFantasia;
            existEmpresa.RazaoSocial = updatedEmpresa.RazaoSocial;
            existEmpresa.Cnpj = updatedEmpresa.Cnpj;
            

            
            _empresaRepository.Update(existEmpresa);
            _empresaRepository.SaveChanges();
            return existEmpresa;
        }
        public EmpresaModel DeleteEmpresa(int id)
        {
            var existEmpresa = _empresaRepository.GetById(id);

            if (existEmpresa == null)
            {
                throw new KeyNotFoundException($"Empresa com o ID {id} não encontrada");
            }

            _empresaRepository.Delete(existEmpresa);
            _empresaRepository.SaveChanges();

            return existEmpresa;
        }

        public IEnumerable<EmpresaModel> GetAllEmpresas()
        {
            return _empresaRepository.GetAll();
        }


        public EmpresaModel GetEmpresaById(int id)
        {
            var empresa = _empresaRepository.GetAll().FirstOrDefault(e => e.EmpresaId == id);
            return empresa;
        }

    }
}
