namespace SoftUniClone.Web.Areas.Admin.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Admin.Models.Users;
    using System.Collections.Generic;
    using Web.Models;

    public class AdminPagesViewModel : PagesViewModel<AdminUserBasicServiceModel>
    {
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}