using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class TransactionService
{
    private readonly AppDbContext _context;
    
    public TransactionService(AppDbContext context)
    {
        _context =  context;
    }

    public async Task<Transaction?> AddTransaction(Transaction transaction, int userId)
    {
        transaction.UserId = userId;
        _context.Transactions.Add(transaction);
       await _context.SaveChangesAsync();
        
        return transaction;
    }

    public async Task<bool> RemoveTransaction(int transactionId, int userId)
    {
        var transactionToRemove = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == transactionId && t.UserId == userId);

        if (transactionToRemove == null) return false;

        _context.Transactions.Remove(transactionToRemove);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Transaction?> UpdateTransaction(int transactionId, int userId, Transaction transactionUpdated)
    {
        var transactionToUpdate = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == transactionId && t.UserId == userId);
        
        if (transactionToUpdate == null) return null;
        
        transactionToUpdate.Amount = transactionUpdated.Amount;
        transactionToUpdate.Category = transactionUpdated.Category;
        transactionToUpdate.Date = transactionUpdated.Date;
        transactionToUpdate.Notes = transactionUpdated.Notes;
        transactionToUpdate.UpdatedAt = DateTime.UtcNow;
        
        _context.Transactions.Update(transactionToUpdate);
        await _context.SaveChangesAsync();
        return transactionToUpdate;
    }

    public async Task<List<Transaction>> GetAllTransactions(int userId)
    {
        return await _context.Transactions.Where(t => t.UserId == userId).OrderByDescending(t => t.Date).ToListAsync();
    }

    public async Task<Transaction?> GetTransactionById(int userId, int transactionId)
    {
        return await _context.Transactions.Where(t => t.Id == transactionId && userId == t.UserId).FirstOrDefaultAsync();
    }
}