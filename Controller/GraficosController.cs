using Microsoft.AspNetCore.Mvc;
using api_cinema.DAO.Graficos;

namespace api_cinema.Controller
{
    [ApiController]
    [Route("grafico")]
    public class GraficosController : ControllerBase
    {
        [HttpGet]
        [Route("faturamento")]
        public IActionResult GetAllFaturamento()
        {
            try
            {
                FaturamentoMensalDAO faturamentoMensalDAO = new FaturamentoMensalDAO();
                
                return Ok(faturamentoMensalDAO.GetAll());
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
        [Route("filmes")]
        public IActionResult GetAllFilmes()
        {
            try
            {
                FilmePopularDAO filmePopularDAO = new FilmePopularDAO();
                
                return Ok(filmePopularDAO.GetAll());
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