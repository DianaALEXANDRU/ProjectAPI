using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    [Authorize]
    public class StockController : ControllerBase
    {
        private StockService stockService { get; set; }

        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet("/get-allStocks")]
        [Authorize(Roles = "Administrator, User")]
        public ActionResult<List<Stock>> GetAll()
        {
            var result = stockService.GetAll();
            return Ok(result);
        }

        [HttpPost("/addStock")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Add([FromBody] StockAddDto payload)
        {
            var result = stockService.AddStock(payload);

            if (result == null)
            {
                return BadRequest("Stock cannot be added");
            }

            return Ok(result);
        }


        [HttpDelete("/deleteStock/{stockId}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Product> DeleteById(int stockId)
        {
            var result = stockService.DeleteById(stockId);

            if (result == null)
            {
                return BadRequest("Stock not found!");
            }

            return Ok(result);
        }

    }
}
