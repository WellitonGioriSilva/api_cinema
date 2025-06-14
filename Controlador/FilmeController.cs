using Microsoft.AspNetCore.Mvc;
using api_cinema.Mapeamento;
using api_cinema.Models;

namespace api_cinema.Controlador
{
    [ApiController]
    [Route("filme")]
    public class FilmeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                FilmeMap filmeMap = new FilmeMap();
                var filmes = filmeMap.getAll();

                return Ok(filmes);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                System.Console.WriteLine("Fecha o bd");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeMap filmeMap = new FilmeMap();
                var filmes = filmeMap.getById(id);

                return Ok(filmes);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                System.Console.WriteLine("Fecha o bd");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Filme filme)
        {
            try
            {
                FilmeMap filmeMap = new FilmeMap();
                filmeMap.create(filme);

                return Ok("Salvo com sucesso!");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                System.Console.WriteLine("Fecha o bd");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Filme filme, int id)
        {
            try
            {
                //FilmeMap filmeMap = new FilmeMap();
                //filmeMap.create(filme);

                return Ok("Salvo com sucesso!");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                System.Console.WriteLine("Fecha o bd");
            }
        }
    }
}