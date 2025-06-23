using Microsoft.AspNetCore.Mvc;
using api_cinema.DAO;
using api_cinema.Models;
using api_cinema.Utilities;

namespace api_cinema.Controller
{
    [ApiController]
    [Route("formaPagamento")]
    public class FormaPagamentoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(string nome = "")
        {
            try
            {
                FormaPagamentoDAO formaPagamentoDAO = new FormaPagamentoDAO();
                return Ok(formaPagamentoDAO.GetAll(nome));
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
                FormaPagamentoDAO formaPagamentoDAO = new FormaPagamentoDAO();
                var formaPagamento = formaPagamentoDAO.GetById(id);

                return Ok(formaPagamento);
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