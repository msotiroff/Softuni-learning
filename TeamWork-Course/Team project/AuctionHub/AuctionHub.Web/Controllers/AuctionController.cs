﻿namespace AuctionHub.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.AuctionViewModels;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using AuctionHub.Services.Models.Auctions;
    using System;

    public class AuctionController : BaseController
    {
        private readonly IAuctionService auctionService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<User> userManager;
        private readonly IBidService bids;

        public AuctionController(
            IAuctionService auctionService, 
            UserManager<User> userManager, 
            IProductService productService, 
            ICategoryService categoryService,
            IBidService bids)
        {
            this.auctionService = auctionService;
            this.userManager = userManager;
            this.productService = productService;
            this.categoryService = categoryService;
            this.bids = bids;
        }

        //GET Auction Index
        [HttpGet]
        public IActionResult Index()
        {
            var auctions = this.auctionService.IndexAuctionsList()
                               .Select(a => new IndexAuctionViewModel()
                               {
                                   PicturePath = a.Product.Pictures.FirstOrDefault()?.Path,
                                   Description = a.Description,
                                   EndDate = a.EndDate,
                                   LastBiddedPrice = a.Bids != null ? a.Bids.Count > 0 ? a.Bids.Last().Value : 0 : 0,
                                   OwnerName = a.Product?.Owner?.Name,
                                   ProductName = a.Product?.Name,
                                   Id = a.Id,
                                   IsActive = a.IsActive,
                                   Price = a.Price
                               }).Where(pr => pr.IsActive == true)
                               .ToList();

            return this.View(auctions);
        }

        //GET Auction/Create
        [HttpGet]
        [Authorize]
        public IActionResult Create(int id)
        {
            var loggedUserId = this.userManager.GetUserId(User);
            
            if(auctionService.IsAuctionExist(id))
            {
                return this.BadRequest("The selected product is already in active/inactive auction!");
            }

            var newAuction = new AuctionFormModel()
            {
                ProductId = id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30),
                IsActive = true
            };

            return View(newAuction);
        }


        //POST Auction/Create
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AuctionFormModel auctionToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(auctionToCreate);
            }
            //Create(string description, decimal price, DateTime startDate, DateTime endDate, int categoryId, int productId)
            User loggedUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);


            if (!this.categoryService.IsCategoryExist(auctionToCreate.CategoryId))
            {
                return this.BadRequest();
            }

            var categoryForAuction = this.categoryService.GetCategoryById(auctionToCreate.CategoryId);

            if (!this.productService.IsProductExist(auctionToCreate.ProductId))
            {
                RedirectToAction(nameof(ProductController.List), "Product");
            }

            var productForAuction = await this.productService.GetProductByIdAsync(auctionToCreate.ProductId);

            if (productForAuction.OwnerId != loggedUser.Id)
            {
                return Forbid();
            }

            if (!IsValid(auctionToCreate))
            {
                return this.BadRequest();
            }

            await this.auctionService.Create(
               auctionToCreate.Description,
               auctionToCreate.Price,
               auctionToCreate.StartDate,
               auctionToCreate.EndDate,
               auctionToCreate.CategoryId,
               auctionToCreate.ProductId);

            return RedirectToAction(nameof(AuctionController.Index), "Auction");
        }

        //GET: Auction/List
        [HttpGet]
        public async Task<IActionResult> List(int page = 1, string search = null, string user = null)
        {
            var pageSize = DataConstants.AuctionToShow;

            var ownerId = this.userManager.GetUserId(User);

            var allAuctions = await this.auctionService.ListAsync(ownerId, page, search);

            var result = allAuctions
                .OrderByDescending(a => a.EndDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                //.Include()
                .Select(a => new IndexAuctionViewModel()
                {
                    Description = a.Description,
                    EndDate = a.EndDate,
                    LastBiddedPrice = a.Bids != null ? a.Bids.Count > 0 ? a.Bids.Last().Value : 0 : 0,
                    OwnerName = a.Product.Owner.Name,
                    Id = a.Id,
                    PicturePath = a.Product.Pictures.FirstOrDefault().Path,
                    ProductName = a.Product.Name
                })
                .ToList();

            // how to make viewbag.currentpage = page;

            return View(result);
        }

        //GET: Auction/Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var userId = this.userManager.GetUserId(User);

            AuctionDetailsServiceModel currentAuction = await this.auctionService.GetAuctionByIdAsync(id, userId);

            if (currentAuction == null)
            {
                return NotFound();
            }

            IEnumerable<Bid> bids = this.bids.GetForAuction(id);

            var model = new AuctionDetailsViewModel
            {
                Auction = currentAuction,
                LastBids = bids,
                CurrentBid = bids.Count() > 0 ? bids.FirstOrDefault(b => b.Value == bids.Select(bd => bd.Value).Max()) : null
            };


            return View(model);
        }

        //GET: Auction/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var loggedUserId = this.userManager.GetUserId(User);

            var currentAuction = await this.auctionService.GetAuctionByIdAsync(id, userId);

            if (currentAuction == null)
            {
                return NotFound();
            }

            if(currentAuction.OwnerId != loggedUserId)
            {
                return BadRequest("You are not owner/administrator of this auction!");
            }

            var model = new AuctionDeleteViewModel
            {
                Auction = currentAuction
            };

            return this.View(model);
        }



        //POST : Auction/Delete
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var currentAuction = await this.auctionService.GetAuctionByIdAsync(id, userId);

            if (currentAuction == null)
            {
                return NotFound();
            }

            await this.auctionService.Delete(id);

            return RedirectToAction(nameof(AuctionController.Index));
        }


        //GET: Auction/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var loggedUserId = this.userManager.GetUserId(User);

            var currentAuction = await this.auctionService.GetAuctionByIdAsync(id, userId);

            if (currentAuction == null)
            {
                return NotFound();
            }

            if (currentAuction.OwnerId != loggedUserId)
            {
                return BadRequest("You are not owner/administrator of this auction!");
            }

            var product = await this.productService.GetProductByNameAsync(currentAuction.ProductName);

            var model = new AuctionEditViewModel()
            {
                Id = currentAuction.Id,
                ProductName = currentAuction.ProductName,
                Description = currentAuction.Description,
                //CategoryName = currentAuction.CategoryName,
                Price = currentAuction.Price,
                ProductId = product.Id
            };

            return View(model);
        }

        //POST: Auction/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(AuctionEditViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(auctionToEdit);
            //}
            var userId = this.userManager.GetUserId(User);

            var auction = await this.auctionService.GetAuctionByIdAsync(model.Id, userId);

            User loggedUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            if(model.Description.Length < DataConstants.AuctionNameMinLength ||
                model.Description.Length > DataConstants.AuctionNameMaxLength)
            {
                return BadRequest("Incorrect input length!");
            }

            //var categoryForAuction = this.categoryService.GetCategoryByName(auction.CategoryName);
            
            //if (categoryForAuction == null)
            //{
            //    return this.BadRequest();
            //}
            
            if (auction.ProductId == 0)
            {
                RedirectToAction(nameof(ProductController.List), "Product");
            }

            if (auction.OwnerId != loggedUser.Id)
            {
                return Forbid();
            }

            if (!IsValid(auction))
            {
                return this.BadRequest();
            }

            await this.auctionService.Edit(
                auction.Id,
                model.ProductName,
                model.Description,
                auction.CategoryName,
                auction.ProductId
                );

            return RedirectToAction(string.Concat(nameof(AuctionController.Details), "/", model.Id), "Auction");


        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }

        private bool IsUserAuthorizedToEdit(string auctionOwnerId, string loggedUserId)
        {
            bool isAdmin = this.User.IsInRole("Administrator");
            bool isAuthor = auctionOwnerId == loggedUserId;

            return isAdmin || isAuthor;
        }

    }
}
