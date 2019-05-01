namespace Judge.App.Controllers
{
    using Judge.App.Models.Contest;
    using Judge.Common.Notifications;
    using Judge.Services.Contracts;
    using Judge.Services.Models;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System;
    using System.Linq;

    public class ContestController : BaseController
    {
        private readonly IContestService contestService;

        public ContestController(IContestService contestService)
        {
            this.contestService = contestService;
        }
        
        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            var allContests = this.contestService.All();

            this.ViewModel["all-contests"]
                = string.Join(Environment.NewLine, allContests.Select(c => this.BuildContestDetailsRow(c)));

            return View();
        }
                
        [HttpGet]
        public IActionResult Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContestCreateViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var success = this.contestService.Add(model.Name, this.Identity.Id);

            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return View();
            }

            this.ShowNotification("Contest created successfully", NotificationType.success);
            return this.All();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var contest = this.contestService.Get(id);

            bool isUserAuthorizedToEdit = this.GetAuthorization(contest.UserId);
            if (!isUserAuthorizedToEdit)
            {
                return Redirect("/contest/all");
            }
            
            if (contest == null)
            {
                this.ShowNotification("Invalid contest!");
                return View();
            }

            this.ViewModel["Id"] = contest.Id.ToString();
            this.ViewModel["Name"] = contest.Name;

            return View();
        }
        
        [HttpPost]
        public IActionResult Edit(ContestUpdateDeleteViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var success = this.contestService.Update(model.Id, model.Name);

            if (!success)
            {
                this.ViewModel["Id"] = model.Id.ToString();
                this.ViewModel["Name"] = model.Name;
                this.ShowNotification(NotificationMessages.InvalidCopntestName);
                return View();
            }

            this.ShowNotification("Contest updated successfully", NotificationType.success);
            return this.All();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var contest = this.contestService.Get(id);

            bool isUserAuthorizedToEdit = this.GetAuthorization(contest.UserId);
            if (!isUserAuthorizedToEdit)
            {
                return Redirect("/contest/all");
            }

            if (contest == null)
            {
                this.ShowNotification("Invalid contest!");
                return View();
            }

            this.ViewModel["Id"] = contest.Id.ToString();
            this.ViewModel["Name"] = contest.Name;

            return View();
        }

        [HttpPost]
        public IActionResult Delete(ContestUpdateDeleteViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var success = this.contestService.Delete(model.Id);

            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return View();
            }

            this.ShowNotification("Contest deleted successfully", NotificationType.success);
            return this.All();
        }

        private bool GetAuthorization(int userId)
            => userId == this.Identity.Id || this.Identity.IsAdmin;

        private string BuildContestDetailsRow(ContestListServiceModel contest)
        {
            var isUserAuthorized = this.Identity.IsAdmin || this.Identity.Id == contest.UserId;
            var authenticatedDisplay = isUserAuthorized
                ? "block-inline"
                : "none";

            var row = $@"<tr>
                            <td scope='row'>{contest.Name}</td>
                            <td>{contest.SubmissionsCount}</td>
                            <td>
                                <a style='display: {authenticatedDisplay}' href = '/contest/edit?id={contest.Id}' class='btn btn-sm btn-warning'>Edit</a>
                                <a style='display: {authenticatedDisplay}' href = '/contest/delete?id={contest.Id}' class='btn btn-sm btn-danger'>Delete</a>
                            </td>
                        </tr>";

            return row;
        }
    }
}
