using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao _dao;

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
                _dao = new AuctionDao();
            else
                _dao = auctionDao;
        }

        [HttpGet("Auctions")]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if(title_like.Length > 0)
            {
                return _dao.SearchByTitle(title_like);
            }
            else if(currentBid_lte > 0)
            {
                return _dao.SearchByPrice(currentBid_lte);
            }
            else
            {
                return _dao.List();
            }
        }

        [HttpGet("Auctions/{id}")]
        public Auction Get(int id)
        {
            return _dao.Get(id);
        }

        [HttpPost("Auctions")]
        public Auction Create(Auction auctionToBeCreated)
        {
            return _dao.Create(auctionToBeCreated);
        }
    }
}
