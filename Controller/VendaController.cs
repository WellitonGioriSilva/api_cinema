using Microsoft.AspNetCore.Mvc;
using api_cinema.DAO;
using api_cinema.Models;
using api_cinema.Utilities;

namespace api_cinema.Controller
{
    [ApiController]
    [Route("venda")]
    public class VendaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(DateTime? dtIni = null)
        {
            try
            {
                VendaDAO vendaDAO = new VendaDAO();
                return Ok(vendaDAO.GetAll(dtIni));
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

        [HttpPost]
        public IActionResult Create([FromBody] VendaRequest request)
        {
            try
            {
                VendaDAO vendaDAO = new VendaDAO();
                vendaDAO.Create(request._venda, request._assentos, request._sessaoId, request._quantidadeMeiaEntrada);
                return Created();
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
                VendaDAO vendaDAO = new VendaDAO();
                var venda = vendaDAO.GetById(id);

                return Ok(venda);
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