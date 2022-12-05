using Microsoft.EntityFrameworkCore;
using SmithTrade.entities;

namespace SmithTrade.repository;

public class WalletRepository : DbContext
{

    public WalletRepository(DbContextOptions<WalletRepository> configuration) : base(configuration)
    {
    }

    public DbSet<Wallet> Wallets { get; set; } = null!;
    
    
    public void AddWallet(Guid userId, string alias)
    {
        Database.ExecuteSqlRaw($"exec AddWallet '{userId}', {alias}");
    }

    public void UpdateWalletAlias(Guid walletId, string alias)
    {
        Database.ExecuteSqlRaw($"exec UpdateWalletAlias '{walletId}', '{alias}'");
    }

    public IEnumerable<Wallet> GetWallets(Guid userId)
    {
        return Wallets.Where(x => x.UserId == userId).ToList();
    }
}