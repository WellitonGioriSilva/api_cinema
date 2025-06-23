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
        public IActionResult GetAll(int? id_filme_fk = 0, DateTime? data = null)
        {
            try
            {
                SessaoDAO sessaoDAO = new SessaoDAO();
                return Ok(sessaoDAO.GetAll(id_filme_fk, data));
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
                var filmes = sessaoDAO.GetById(id);

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
                
            }
        }
    }
}