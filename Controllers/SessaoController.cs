using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context= context;
            _mapper = mapper;

        }

        [HttpPost]
        public IActionResult adicionarSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = sessao.Id }, sessao);

        }
        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(sessaoDto);
            }
            return NotFound();
        }

    }


}
