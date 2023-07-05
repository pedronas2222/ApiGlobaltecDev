using ApiGlobaltecDev.Models;
using ApiGlobaltecDev.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGlobaltecDev.Repositorio
{
    public class UserRepositorio : InterfaceUserRepositorio
    {
        public readonly APIDbContext? APIDbContext;

        public Task<List<PessoasModel>> AutenticarRotas(string Usuario, string Senha)
        {
            throw new NotImplementedException();
        }
    }
}
