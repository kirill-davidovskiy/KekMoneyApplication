using System.ComponentModel.DataAnnotations.Schema;

namespace SmithTrade.entities;

[Table("Transactions", Schema = "Lab4")]
public class Transaction
{
    [Column("id")] public Guid Id { get; set; }
    [Column("walletSender")] public Guid WalletSender { get; set; }
    [Column("walletReceiver")] public Guid WalletReceiver { get; set; }
    [Column("amount")] public float Amount { get; set; }
    [Column("commission")] public float Commission { get; set; }
    [Column("createDate")] public DateTime CreateDate { get; set; }
}