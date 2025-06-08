using Kolokwium_s28508.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_s28508.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Nazwa : ControllerBase
{
    private readonly IDbService _dbService;
    
    public Nazwa(IDbService dbService)
    {
        _dbService = dbService;
    }

   /* 
    [HttpPost("{clientID}/orders")]
    public async Task<IActionResult> AddNewOrder(int clientID, NewOrderDTO newOrder)
    {
        Walidacja czy klient istnieje i czy pracownik istnieje
        if (!await _dbService.DoesClientExist(clientID))
            return NotFound($"Client with given ID - {clientID} doesn't exist");
        if (!await _dbService.DoesEmployeeExist(newOrder.EmployeeID))
            return NotFound($"Employee with given ID - {newOrder.EmployeeID} doesn't exist");
    
        Tworzenie nowego obiektu order
        var order = new Order()
        {
            ClientId = clientID,
            EmployeeId = newOrder.EmployeeID,
            AcceptedAt = newOrder.AcceptedAt,
            Comments = newOrder.Comments,
        };
    
        Sprawdzenie i przygotowanie wypieków
        var pastries = new List<OrderPastry>();
        foreach (var newPastry in newOrder.Pastries)
        {
            var pastry = await _dbService.GetPastryByName(newPastry.Name);
            if(pastry is null)
                return NotFound($"Pastry with name - {newPastry.Name} doesn't exist");
    
            pastries.Add(new OrderPastry
            {
                PastryId = pastry.Id,
                Amount = newPastry.Amount,
                Comment = newPastry.Comments,
                Order = order
            });
        }
    
        Transakcja: dodanie nowego zamówienia i wypieków do bazy danych.
        Jesli cos się nie uda to transakcja zostanie wycofana.
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddNewOrder(order);
            await _dbService.AddOrderPastries(pastries);
    
            scope.Complete();
        }
    
        Zwrócenie odpowiedzi z informacjami o nowym zamówieniu
        return Created("api/orders", new
        {
            Id = order.Id,
            order.AcceptedAt,
            order.FulfilledAt,
            order.Comments,
        });
    }
*/
}