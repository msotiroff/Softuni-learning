namespace Judge.App.Controllers
{
    using Common.Notifications;
    using Models.Submission;
    using Services.Contracts;
    using Services.Models;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class SubmissionController : BaseController
    {
        private readonly ISubmissionService submissionService;
        private readonly IContestService contestService;

        public SubmissionController(ISubmissionService submissionService, IContestService contestService)
        {
            this.submissionService = submissionService;
            this.contestService = contestService;
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var allContests = this.contestService
                .All()
                .Where(c => c.UserId == this.Identity.Id)
                .OrderBy(c => c.Id)
                .ToArray();

            this.ViewModel["all-contests"] = string
                .Join(string.Empty,
                    allContests.Select(c => this.BuildContestsListItem(c.Id.ToString(), c.Name)));

            this.ViewModel["all-submissions"] = this.BuildSubmissionViewItems(allContests);

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var allContests = this.contestService.All();

            this.ViewModel["contests"] = string
                .Join(Environment.NewLine, allContests
                    .Select(c => this.BuildContestsSelectOptions(c)));

            return View();
        }

        [HttpPost]
        public IActionResult Add(SubmissionCreateViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var compiled = this.GetRandomBoolean();

            var success = this.submissionService
                .Add(model.ExecutableCode, model.ContestId, this.Identity.Id, compiled);

            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return View();
            }

            this.ShowNotification("Submission added successfully", NotificationType.success);
            return this.All();
        }

        private string BuildSubmissionViewItems(ContestListServiceModel[] contests)
        {
            var builder = new StringBuilder();

            foreach (var contest in contests)
            {
                builder.AppendLine($@"<div class='tab-pane fade' id='{contest.Id}' role='tabpanel'>");

                if (!contest.Submissions.Any())
                {
                    builder.AppendLine("<ul class='list-group'></ul>");
                    continue;
                }
                else
                {
                    foreach (var submission in contest.Submissions)
                    {
                        this.AddSubmissionToHtmlList(builder, submission);
                    }
                }

                builder.AppendLine("</div>");
            }

            return builder.ToString();
        }

        private void AddSubmissionToHtmlList(StringBuilder builder, SubmissionListServiceModel submission)
        {
            var buildSuccess = submission.Compiled
                                        ? "Build Success"
                                        : "Build Failed";

            var buildViewType = submission.Compiled
                ? "list-group-item list-group-item-success"
                : "list-group-item list-group-item-danger";

            var submissionRow = $@"<ul class='list-group'>
                                            <li class='{buildViewType}'>{buildSuccess}</li>
                                        </ul>";

            builder.AppendLine(submissionRow);
        }

        private string BuildContestsListItem(string contestId, string contestName)
        {
            return $"<a class='list-group-item list-group-item-action list-group-item-dark' data-toggle='list' href='#{contestId}' role='tab'>{contestName}</a>";
        }

        private string BuildContestsSelectOptions(ContestListServiceModel contest)
        {
            return $"<option value='{contest.Id}'>{contest.Name}</option>";
        }

        private bool GetRandomBoolean()
        {
            var random = new Random();

            var randomNumber = random.Next(1, 11);

            return randomNumber > 7;
        }
    }
}
