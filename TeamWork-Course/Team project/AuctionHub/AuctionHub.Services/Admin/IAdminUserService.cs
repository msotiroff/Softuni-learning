﻿namespace AuctionHub.Services.Admin
{
    using Services.Admin.Models.Users;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        Task<IEnumerable<UserListingServiceModel>> AllAsync();
    }
}
