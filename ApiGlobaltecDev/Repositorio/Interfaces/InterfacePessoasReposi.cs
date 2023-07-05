using ApiGlobaltecDev.Models;

namespace ApiGlobaltecDev.Repositorio.Interfaces
{
    public interface InterfacePessoasRepositorio
    {
        Task<List<PessoasModel>> BuscaPorUF(string uf);
    }
}
