using System.ComponentModel.DataAnnotations.Schema;

namespace KekMoneyApplication.entities;

[Table("Users", Schema = "Lab4")]
public class User
{
    [Column("id")] public Guid Id { get; set; }
    [Column("username")] public string Username { get; set; }
    [Column("password")] public string Password { get; set; }
    [Column("createDate")] public DateTime CreateDate { get; set; }
    [Column("isPremium")] public bool IsPremium { get; set; }
}