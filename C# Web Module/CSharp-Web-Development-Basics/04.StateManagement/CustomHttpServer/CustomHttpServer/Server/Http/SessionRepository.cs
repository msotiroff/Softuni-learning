namespace CustomHttpServer.Server.Http
{
    using System.Collections.Concurrent;

    public static class SessionRepository
    {
        public const string SessionCookieKey = "SESSION_ID";

        private static readonly ConcurrentDictionary<string, HttpSession> sessions =
            new ConcurrentDictionary<string, HttpSession>();

        public static HttpSession Get(string id)
            => sessions.GetOrAdd(id, _ => new HttpSession(id));
    }
}
