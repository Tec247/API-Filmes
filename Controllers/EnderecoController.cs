using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper =mapper;
        }


        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto); 

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = endereco.Id }, endereco);

        }
        [HttpGet]
        public IEnumerable<Endereco> RetornarEndereco()
        {
            return _context.Enderecos;
            //return Ok(_context.Filmes) ;
        }
        [HttpGet("{id}")] 
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);  

                return Ok(enderecoDto);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarEnderco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id ==id);
            if(endereco == null)
            {
                return NotFound();             
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id ==id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent(); // Boa prática pois não devemos trazer nenhuma informação e sim um status 204 para atualização e deleção
        }
    }
}
