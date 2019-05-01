namespace MeTube.App.Controllers
{
    using System;
    using System.Web;
    using MeTube.App.Models.Tube;
    using MeTube.Common.Notifications;
    using MeTube.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class TubeController : BaseController
    {
        private readonly ITubeService tubeService;

        public TubeController(ITubeService tubeService)
        {
            this.tubeService = tubeService;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Upload(TubeUploadViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return View();
            }

            var youTubeId = this.GetYouTubeId(model.YouTubeLink);
            if (youTubeId == null)
            {
                this.ShowNotification("Invalid YouTube link!");
                return View();
            }

            var uploaderId = this.Identity.Id;

            var uploadedTubeIdentifier = this.tubeService.Upload(model.Title, model.Description, model.Author, uploaderId, youTubeId);
            if (uploadedTubeIdentifier == 0)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return View();
            }

            this.ShowNotification("Video uploaded successfully!", NotificationType.success);
            return this.Details(uploadedTubeIdentifier);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var tube = this.tubeService.GetById(id);

            this.Model["title"] = tube.Title;
            this.Model["author"] = tube.Author;
            this.Model["views"] = tube.Views.ToString();
            this.Model["description"] = tube.Description;
            this.Model["tubeId"] = tube.YouTubeId;

            return View();
        }

        private string GetYouTubeId(string youTubeLink)
        {
            try
            {
                var youTubeUri = new Uri(youTubeLink);

                if (youTubeLink.Contains("youtu.be"))
                {
                    return youTubeUri.AbsolutePath.Substring(1);
                }

                return HttpUtility.ParseQueryString(youTubeUri.Query)["v"];
            }
            catch (UriFormatException)
            {
                return null;
            }
        }
    }
}
