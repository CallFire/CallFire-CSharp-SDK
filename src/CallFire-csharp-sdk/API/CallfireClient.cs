namespace CallFire_csharp_sdk.API
{
    public class CallfireClient : ICallfireClient
    {
        private readonly string _username;
        private readonly string _password;
        private readonly CallfireClients _client;

        public CallfireClient(string username, string password, CallfireClients client)
        {
            _username = username;
            _password = password;
            _client = client;
        }
    }
}
