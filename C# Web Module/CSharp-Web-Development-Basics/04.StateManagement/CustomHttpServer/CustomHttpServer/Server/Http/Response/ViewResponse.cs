namespace CustomHttpServer.Server.Http.Response
{
    using Contracts;
    using CustomHttpServer.Server.Common;
    using Enums;
    using Infrastructure.Extensions.CustomExceptions;

    public class ViewResponse : HttpResponse
    {
        private const string NotViewResponseErrorMsg = "View responses need a status code below 300 and above 400 (inclusive)!";

        private readonly IView view;

        public ViewResponse(HttpStatusCode responseCode, IView view)
        {
            CommonValidator.ThrowIfNull(responseCode, nameof(responseCode));
            CommonValidator.ThrowIfNull(view, nameof(view));
            this.ValidateStatusCode(responseCode);

            this.StatusCode = responseCode;
            this.view = view;
        }

        protected override string BuildResponse()
        {
            var response = base.BuildResponse() + this.view.View();

            return response;
        }

        private void ValidateStatusCode(HttpStatusCode responseCode)
        {
            var statusCodeNumber = (int)responseCode;

            var isViewResponse = statusCodeNumber < 300 || statusCodeNumber > 399;

            if (!isViewResponse)
            {
                throw new InvalidResponseException(NotViewResponseErrorMsg);
            }
        }
    }
}
