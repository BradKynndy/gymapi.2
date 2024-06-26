using Gymapi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace Gymapi.Controllers
{
    [ApiController]
    [Route("[controllers]")]
    public class MembersEmailController : ControllerBase
    {
        private readonly DataContext _context;
        
        public MembersEmailController(DataContext context)
        {
            _context = context;
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddMembersEmailcontaAsync(MembersEmailController novoMemberEmail)
    {
        try
        {
            Members members = await _context.TB_MEMBERS
                .Include(p =>classe)
                .Include(p =>p.MembersEmail).ThenInclude(Ps => Ps.Email)
                .FistOrDefaultAsync(p => p.Id == novoMemberEmail.MemberId);

                if (personagem == null)
                    throw new System.Exception("Personagem não encontrado para o Id Informado.");

                Nivelconta nivelconta = await _contex.Tb_MEMBERS
                                    .FistOrDefaultAsync(h => h.Id == novoMemberEmail.EmailId);
                        
                if (email ==null)
                    throw new System.Exception("Email não encontrado")

                MembersEmail ph = new MembersEmail();
                ph.Members = members;
                ph.Email = email
                await _contex.TB_MEMBERS_EMAILS.AddAsync(ph);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
                // continuar passo 14 slide 11.1
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message)
        }
    }
}