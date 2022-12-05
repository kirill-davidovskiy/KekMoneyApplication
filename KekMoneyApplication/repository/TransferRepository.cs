using Microsoft.EntityFrameworkCore;
using SmithTrade.entities;

namespace SmithTrade.repository;

public class TransferRepository : DbContext
{

    public TransferRepository(DbContextOptions<TransferRepository> configuration) : base(configuration)
    {
    }

    public DbSet<Transaction> Transactions { get; set; } = null!;
    
    
    public void AddTransaction(Guid userId, Guid walletIdFrom, Guid walletIdTo, double amount, double commission)
    {
        Database.ExecuteSqlRaw($"exec AddTransaction '{userId}', '{walletIdFrom}', '{walletIdTo}', {amount}, {commission}");
    }

    public void BuyPremium(Guid userId, Guid walletId, double amount)
    {
        Database.ExecuteSqlRaw($"exec BuyPremium '{userId}', '{walletId}', {amount}");
    }

    public IEnumerable<Transaction> GetTransactions(Guid walletId)
    {
        return Transactions.Where(x => x.WalletReceiver == walletId || x.WalletSender == walletId).ToList();
    }
}