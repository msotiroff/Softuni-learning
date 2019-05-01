﻿namespace HTTPServer.Http
{
    using System.Collections.Concurrent;

    public static class SessionStore
    {
        public const string SessionCookieKey = "MY_SID";
        public const string CurrentUserKey = "Current_User_Session_Key";
        public const string CurrentUserIsAdminKey = "Current_User_IsAdmin_Key";
        public const string CurrentShoppingCartSessionKey = "Current_Shopping_Cart_Key";
        
        private static readonly ConcurrentDictionary<string, HttpSession> sessions =
            new ConcurrentDictionary<string, HttpSession>();

        public static HttpSession Get(string id)
            => sessions.GetOrAdd(id, _ => new HttpSession(id));
    }
}
