using Microsoft.AspNetCore.Mvc;
using api_cinema.DAO;
using api_cinema.Models;
using api_cinema.Utilities;

namespace api_cinema.Controller
{
    [ApiController]
    [Route("ingresso")]
    public class IngressoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(int idVenda)
        {
            try
            {
                IngressoDAO ingressoDAO = new IngressoDAO();
                return Ok(ingressoDAO.GetAll(idVenda));
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
    }
}