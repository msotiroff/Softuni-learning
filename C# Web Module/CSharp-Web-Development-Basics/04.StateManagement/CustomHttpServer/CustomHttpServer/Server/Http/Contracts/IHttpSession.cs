namespace CustomHttpServer.Server.Http.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        string GetParameter(string key);

        void Add(string key, string value);

        void Clear();
    }
}
