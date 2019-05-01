namespace MeTube.App.Controllers
{
    using MeTube.Services.Contracts;
    using MeTube.Services.Models.Tube;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class HomeController : BaseController
    {
        private readonly ITubeService tubeService;

        public HomeController(ITubeService tubeService)
        {
            this.tubeService = tubeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!this.User.IsAuthenticated)
            {
                this.Model["welcomeDisplay"] = "none";
                return View();
            }

            var allTubes = this.tubeService.All();

            this.Model["welcomeDisplay"] = "block";
            this.Model["tubes"] = this.BuildTubeListAsHtmlText(allTubes);

            return View();
        }

        private string BuildTubeListAsHtmlText(IEnumerable<TubeListServiceModel> allTubes)
        {
            var builder = new StringBuilder();
            
            foreach (var tube in allTubes)
            {
                var thumbnail = $"http://img.youtube.com/vi/{tube.YouTubeId}/0.jpg";
                
                builder.AppendLine(
                    $@"<div class=""mx-auto"" style=""width: 330px;"">
                               <a href=""/tube/details?id={tube.Id}"">
                                <img style=""width: 300px; height: 170px;"" src=""{thumbnail}"">
                            </a>
                            <div>
                                <h5>{tube.Title}</h5>
                                <p>{tube.UploaderUsername}</p>
                            </div>
                       </div>
                    ");
            }

            return builder.ToString();
        }
    }
}
