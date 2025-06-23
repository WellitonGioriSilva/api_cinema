using Microsoft.AspNetCore.Mvc;
using api_cinema.DAO;
using api_cinema.Models;
using api_cinema.Utilities;

namespace api_cinema.Controller
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(string nome = "")
        {
            try
            {
                ClienteDAO clienteDAO = new ClienteDAO();
                return Ok(clienteDAO.GetAll(nome));
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
                ClienteDAO clienteDAO = new ClienteDAO();
                var cliente = clienteDAO.GetById(id);

                return Ok(cliente);
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