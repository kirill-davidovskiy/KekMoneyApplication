using System.ComponentModel.DataAnnotations.Schema;

namespace KekMoneyApplication.entities;

[Table("Wallets", Schema = "Lab4")]
public class Wallet
{
    [Column("id")] public Guid Id { get; set; }
    [Column("userId")] public Guid UserId { get; set; }
    [Column("createDate")] public DateTime CreateDate { get; set; }
    [Column("balance")] public double Balance { get; set; }
    [Column("alias")] public string Alias { get; set; }
}