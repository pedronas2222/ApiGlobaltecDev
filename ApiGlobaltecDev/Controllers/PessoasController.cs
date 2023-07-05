using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGlobaltecDev.Models;
using Microsoft.AspNetCore.Authorization;
using ApiGlobaltecDev.Models.Services;

namespace ApiGlobaltecDev.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly APIDbContext _context;

        public PessoasController(APIDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Autenticar totas
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Senha"></param>
        /// <returns></returns>
        [HttpGet("autenticar/")]
        public IActionResult Auth(string Usuario, string Senha)
        {
            if (Usuario == "pedro" && Senha == "123")
            {
                var token = TokenService.GenerateToken(new ApiGlobaltecDev.Models.PessoasModel());
                return Ok(token);
            }

            return BadRequest("Usuário ou senha inválidos.");
        }
        // fim autenticação


        // GET: api/Pessoas
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Listagem/")]
        public async Task<ActionResult<IEnumerable<PessoasModel>>> GetPessoas()
        {
          if (_context.Pessoas == null)
          {
                return NotFound();
          }
            return await _context.Pessoas.ToListAsync();
        }


        // AQUI, iremos buscar pessoas com o "código" especificado
        // GET: api/Pessoas/5

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("BuscaPorCodigo/{id}")]
        public async Task<ActionResult<PessoasModel>> GetPessoasModel(int id)
        {
            if (_context.Pessoas == null)
            {
                return NotFound();
            }
            var pessoasModel = await _context.Pessoas.FindAsync(id);

            if (pessoasModel == null)
            {
                return NotFound($"Não encontramos nenhuma pessoa com o código: {id}");
            }

            return pessoasModel;

        }


        // GET: api/Pessoas/UF
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("BuscaPorUF/")]
        public List<PessoasModel> SearchByName(string uf)
        {
            return _context.Pessoas.Where(p => p.uf.Contains(uf)).ToList();
        }


        // PUT: api/Pessoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("AlterarDados/{codigo}")]
        public async Task<IActionResult> PutPessoasModel(int codigo, PessoasModel pessoasModel)
        {
            if (codigo != pessoasModel.Codigo)
            {
                return BadRequest();
            }

            //if (cpfCnpj = pessoasModel.cpfCnpj)
            //{
            //    return NotFound("CPF já existe");
            //}

            _context.Entry(pessoasModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoasModelExists(codigo))
                {
                    return NotFound("Falha!");
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Os dados de {pessoasModel.Nome}, foram alterados com sucesso");
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Cadastro/")]
        public async Task<ActionResult<PessoasModel>> PostPessoasModel(PessoasModel pessoasModel)
        {
          if (_context.Pessoas == null)
          {
              return Problem("Entity set 'APIDbContext.Pessoas'  is null.");
            }
            _context.Pessoas.Add(pessoasModel);
            await _context.SaveChangesAsync();
            return Ok("Salvo!");
            //return CreatedAtAction("GetPessoasModel", new { id = pessoasModel.Codigo }, pessoasModel);
        }

        // DELETE: api/Pessoas/5
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("DeletarPessoa/{id}")]
        public async Task<IActionResult> DeletePessoasModel(int id)
        {
            if (_context.Pessoas == null)
            {
                return NotFound();
            }
            var pessoasModel = await _context.Pessoas.FindAsync(id);
            if (pessoasModel == null)
            {
                return NotFound("404 - Verifique a chamada há um erro.");
            }

            _context.Pessoas.Remove(pessoasModel);
            await _context.SaveChangesAsync();

            return Ok($"Deletado com sucesso! {id}");
        }

        private bool PessoasModelExists(int id)
        {
            return (_context.Pessoas?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
