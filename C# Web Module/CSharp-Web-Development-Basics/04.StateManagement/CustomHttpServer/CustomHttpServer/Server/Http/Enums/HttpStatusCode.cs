namespace CustomHttpServer.Server.Http.Enums
{
    public enum HttpStatusCode
    {
        OK = 200,
        MovedPermanently = 301,
        Found = 302,
        MovedTEmporarily = 303,
        NotAuthorized = 401,
        NotFound = 404,
        InternalServerError = 500
    }
}
