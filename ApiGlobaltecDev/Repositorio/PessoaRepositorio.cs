using ApiGlobaltecDev.Models;
using ApiGlobaltecDev.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGlobaltecDev.Repositorio
{
    public class PessoaRepositorio : InterfacePessoasReposi
    {
        public readonly APIDbContext? APIDbContext;

        public Task<List<PessoasModel>> BuscaPorUF(string uf)
        {
            return Task.FromResult(APIDbContext.Pessoas.Where(x => x.uf.Contains(uf)).ToList());
            throw new NotImplementedException();
        }
    }
}
