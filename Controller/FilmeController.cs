using Microsoft.AspNetCore.Mvc;
using api_cinema.DAO;
using api_cinema.Models;
using api_cinema.Utilities;

namespace api_cinema.Controller
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
                FilmeDAO filmeDAO = new FilmeDAO();
                return Ok(filmeDAO.getAll());
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
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDAO filmeDAO = new FilmeDAO();
                var filmes = filmeDAO.getById(id);

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
                FilmeDAO filmeDAO = new FilmeDAO();
                filmeDAO.create(filme);

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
                //FilmeDAO filmeMap = new FilmeDAO();
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