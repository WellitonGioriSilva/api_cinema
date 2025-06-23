using Microsoft.AspNetCore.Mvc;
using api_cinema.DAO;
using api_cinema.Models;
using api_cinema.Utilities;

namespace api_cinema.Controller
{
    [ApiController]
    [Route("assento")]
    public class AssentoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                AssentoDAO assentoDAO = new AssentoDAO();
                return Ok(assentoDAO.GetAll());
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

        [HttpGet]
        [Route("livre")]
        public IActionResult GetAllFree([FromQuery] int idSessao)
        {
            try
            {
                AssentoDAO assentoDAO = new AssentoDAO();

                int totalAssentos = 0;
                List<Assento> assentos = assentoDAO.GetAllFree(idSessao, out totalAssentos);
                
                return Ok(new { assentos, totalAssentos });
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
                AssentoDAO assentoDAO = new AssentoDAO();
                var filmes = assentoDAO.GetById(id);

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