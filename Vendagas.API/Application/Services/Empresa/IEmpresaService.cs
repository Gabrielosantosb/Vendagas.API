using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Empresa;

namespace Vendagas.API.Application.Services.Empresa
{
    public interface IEmpresaService
    {
        IEnumerable<EmpresaModel> GetAllEmpresas();
        EmpresaModel GetEmpresaById(int id);

        EmpresaModel CreateEmpresa(CreateEmpresaModel report);
        EmpresaModel UpdateEmpresa(int id, CreateEmpresaModel updatedReport);
        EmpresaModel DeleteEmpresa(int id);
        int CountAllEmpresas();
    }
}
