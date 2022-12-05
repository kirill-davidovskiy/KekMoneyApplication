namespace SmithTrade.dto;

public class ChangeAliasRequest
{
    public Guid WalletId { get; set; }
    public string Alias { get; set; }
}