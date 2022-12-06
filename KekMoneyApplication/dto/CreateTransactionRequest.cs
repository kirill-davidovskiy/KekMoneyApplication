namespace KekMoneyApplication.dto;

public class CreateTransactionRequest
{
    public Guid UserId {get; set; }
    public Guid WalletIdFrom {get; set; }
    public Guid WalletIdTo {get; set; }
    public double Amount {get; set; }
}