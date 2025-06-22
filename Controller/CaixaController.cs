using Microsoft.AspNetCore.Mvc;
using api_cinema.DAO;
using api_cinema.Models;
using api_cinema.Utilities;

namespace api_cinema.Controller
{
    [ApiController]
    [Route("caixa")]
    public class CaixaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(DateTime? dtIni = null)
        {
            try
            {
                CaixaDAO caixaDAO = new CaixaDAO();
                return Ok(caixaDAO.GetAll(dtIni));
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
                CaixaDAO caixaDAO = new CaixaDAO();
                var caixa = caixaDAO.GetById(id);

                return Ok(caixa);
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