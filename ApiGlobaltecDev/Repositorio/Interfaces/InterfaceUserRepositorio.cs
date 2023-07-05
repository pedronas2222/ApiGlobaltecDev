using ApiGlobaltecDev.Models;

namespace ApiGlobaltecDev.Repositorio.Interfaces
{
    public interface InterfaceUserRepositorio
    {
        Task<List<PessoasModel>> AutenticarRotas(string Usuario, string Senha);
    }
}
