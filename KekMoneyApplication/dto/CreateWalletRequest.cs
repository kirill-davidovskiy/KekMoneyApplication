namespace SmithTrade.dto;

public class CreateWalletRequest
{
    public Guid UserId {get; set; }
    public string Alias {get; set; }
}