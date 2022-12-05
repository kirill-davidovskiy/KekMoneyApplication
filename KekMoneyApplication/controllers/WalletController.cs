using Microsoft.AspNetCore.Mvc;
using SmithTrade.dto;
using SmithTrade.entities;
using SmithTrade.repository;

namespace SmithTrade.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly WalletRepository _repository;

        public WalletController(WalletRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get-by-user")]
        public ActionResult<IEnumerable<Wallet>> GetWalletsByUser([FromQuery] Guid userId)
        {
            return Ok(_repository.GetWallets(userId));
        }

        [HttpPost("change-alias")]
        public ActionResult ChangeAlias(ChangeAliasRequest request)
        {
            try
            {
                _repository.UpdateWalletAlias(request.WalletId, request.Alias);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create-wallet")]
        public ActionResult CreateWallet(CreateWalletRequest request)
        {
            _repository.AddWallet(request.UserId, request.Alias);
            return Ok();
        }
    }
}