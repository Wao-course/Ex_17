using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Nozama.OrderService.Model;

[ApiController]
[Route("[controller]")]
public class OrderOrchestratorController : ControllerBase
{
    private readonly OrderOrchestratorService _orderOrchestratorService;

    public OrderOrchestratorController(OrderOrchestratorService orderOrchestratorService)
    {
        _orderOrchestratorService = orderOrchestratorService;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(Order order)
    {
        try
        {
            await _orderOrchestratorService.PlaceOrder(order);
            return Ok("Order placed successfully.");
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            return StatusCode(500, "An error occurred while processing the order.");
        }
    }
}
