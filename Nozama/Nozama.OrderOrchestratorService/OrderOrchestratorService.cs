using System;
using System.Net.Http;
using System.Threading.Tasks;
using Nozama.OrderService.Model;
using System.Net.Http.Json;

public class OrderOrchestratorService
{
    private readonly HttpClient _httpClient;
    
    public OrderOrchestratorService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task PlaceOrder(Order order)
    {
        // Step 1: Place order
        var orderResponse = await _httpClient.PostAsJsonAsync("http://localhost:5300/order/", order);
        orderResponse.EnsureSuccessStatusCode();

        // Step 2: Process payment
        var paymentResponse = await _httpClient.PostAsJsonAsync("http://localhost:5500/payment/", order.Payment);
        paymentResponse.EnsureSuccessStatusCode();

        // Step 3: Update inventory
        var inventoryResponse = await _httpClient.PutAsJsonAsync("http://localhost:5400/inventory/update", order.InventoryUpdate);
        inventoryResponse.EnsureSuccessStatusCode();

        // Order process completed successfully
    }
}
