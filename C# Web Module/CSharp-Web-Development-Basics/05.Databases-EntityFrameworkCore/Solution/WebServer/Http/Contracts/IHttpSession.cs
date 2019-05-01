﻿namespace HTTPServer.Http.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        object Get(string key);

        T Get<T>(string key);

        void Add(string key, object value);

        void Clear();

        bool Contains(string currentUserKey);

        object this[string key] { get; }
    }
}
