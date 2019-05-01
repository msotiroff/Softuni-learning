﻿namespace AuctionHub.Web.Models.AuctionViewModels
{
    using AuctionHub.Services.Models.Auctions;
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AuctionDeleteViewModel : IMapFrom<Auction>
    {
        public AuctionDetailsServiceModel Auction { get; set; }
    }
}
