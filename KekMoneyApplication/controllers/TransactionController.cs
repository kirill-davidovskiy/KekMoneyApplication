using Microsoft.AspNetCore.Mvc;
using KekMoneyApplication.dto;
using KekMoneyApplication.repository;

namespace KekMoneyApplication.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransferRepository _context;
        
        private const double CommissionAmount = 1;
        private const double PremiumAmount = 1;

        public TransactionController(TransferRepository context)
        {
            _context = context;
        }
        
        // [HttpPost("create-transaction")]
        // public ActionResult CreateTransaction(CreaTra request)
        // {
        //     _repository.AddUser(request.UserName, request.Password);
        //     return Ok();
        // }
        
        
        [HttpPost("create")]
        public ActionResult CreateTransaction(CreateTransactionRequest request)
        {
            try
            {
                _context.AddTransaction(request.UserId, request.WalletIdFrom, request.WalletIdTo, request.Amount, CommissionAmount);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        [HttpPost("buy-premium")]
        public ActionResult BuyPremium(BuyPremiumRequest request)
        {
            try
            {
                _context.BuyPremium(request.UserId, request.WalletId, PremiumAmount);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
