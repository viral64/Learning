using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hub;

namespace SignalRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOfferController : ControllerBase
    {
        private readonly IHubContext<MessageHub, IMessageHubClient> _messageHub;
        private static StaticData _staticData = new StaticData();

        public ProductOfferController(IHubContext<MessageHub, IMessageHubClient> messageHub)
        {
            _messageHub = messageHub;
        } 

        // Get the list of products for auction
        [HttpGet]
        [Route("getProducts")]
        public IActionResult GetProducts()
        {
            return Ok(_staticData.Data);
        }

        // Place a bid on a product
        [HttpPost]
        [Route("placeBid")]
        public async Task<IActionResult> PlaceBid([FromBody] BidRequest bidRequest)
        {
            
            var product = _staticData.Data.FirstOrDefault(p => p.Id == bidRequest.ProductId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

          
            if (!decimal.TryParse(product.CurrentBid.Replace("$", "").Trim(), out decimal currentBidAmount))
            {
                return BadRequest("The current bid amount is invalid.");
            }

        
            if (!decimal.TryParse(bidRequest.BidAmount.Replace("$","").Trim(), out decimal newBidAmount))
            {
                return BadRequest("The new bid amount is invalid.");
            }

          
            if (newBidAmount <= currentBidAmount)
            {
                return BadRequest("The new bid amount must be higher than the current bid.");
            }

            
            product.CurrentBid = bidRequest.BidAmount;
            await _messageHub.Clients.All.ReceiveNotification($"New bid placed: {product.Title} - {bidRequest.BidAmount}");

            return Ok("Bid placed successfully.");
        }

    }

    // Request DTO for placing a bid
    public class BidRequest
    {
        public int ProductId { get; set; }
        public string BidAmount { get; set; }
    }
}
