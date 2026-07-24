using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController: ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        this._transactionService = transactionService;
    }
    
    [HttpGet("{id}/user/{userId}")]
    public async Task<IActionResult> GetTransaction([FromRoute] int id, [FromRoute] int userId)
    {
        var transaction = await _transactionService.GetTransactionById(id, userId);
        if (transaction == null)
        {
            return NotFound(new { message = "Transaction not found." });
        }
        
        return Ok(transaction);
    }

    [HttpGet("getAllTransactions/user/{userId}")]
    public async Task<IActionResult> GetAllTransactions([FromRoute] int userId)
    {
        var transactions = await _transactionService.GetAllTransactions(userId);
        return Ok(transactions);
    }

    [HttpPost("addTransaction/user/{userId}")]
    public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction, [FromRoute] int userId)
    {
        var result = await _transactionService.AddTransaction(transaction, userId);

        if (result == null)
        {
            return BadRequest(new { message = "Transaction not added." });
        }
        return Created($"/api/transaction/addTransaction/user/{userId}", transaction);
    }

    [HttpPut("updateTransaction/{id}/user/{userId}")]
    public async Task<IActionResult> UpdateTransaction([FromBody] Transaction transaction, [FromRoute] int userId, [FromRoute] int id)
    {
        var transactionUpdated = await _transactionService.UpdateTransaction(id, userId, transaction );

        if (transactionUpdated == null)
        {
            return NotFound(new { message = "Transaction not found." });
        }
        return Ok(transactionUpdated);
    }

    [HttpDelete("deleteTransaction/{id}/user/{userId}")]
    public async Task<IActionResult> DeleteTransaction([FromRoute] int id, [FromRoute] int userId)
    {
        var transactionDeleted = await _transactionService.RemoveTransaction(id, userId);
        if (transactionDeleted)
        {
            return Ok(new { message = "Transaction successfully deleted." });
        }
        return NotFound(new { message = "Transaction not found." });
    }
}