using Microsoft.AspNetCore.Mvc;
using api_cinema.DAO;
using api_cinema.Models;
using api_cinema.Utilities;

namespace api_cinema.Controller
{
    [ApiController]
    [Route("sessao")]
    public class SessaoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(int id, int id_filme_fk = 0)
        {
            try
            {
                SessaoDAO sessaoDAO = new SessaoDAO();
                return Ok(sessaoDAO.getAll(id, id_filme_fk));
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
                SessaoDAO sessaoDAO = new SessaoDAO();
                var filmes = sessaoDAO.getById(id);

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
                SessaoDAO sessaoDAO = new SessaoDAO();
                sessaoDAO.create(filme);

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
                //SessaoDAO filmeMap = new SessaoDAO();
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