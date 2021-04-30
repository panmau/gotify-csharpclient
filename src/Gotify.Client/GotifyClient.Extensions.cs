namespace Gotify.Client
{
    public partial interface IGotifyClient
    {
        void SetAuthenticationRequestHeader(string token);
    }

    public partial class GotifyClient
    {
        private const string AuthenticationRequestHeaderName = "X-Gotify-Key";

        public void SetAuthenticationRequestHeader(string token)
        {
            if (_httpClient.DefaultRequestHeaders.Contains(AuthenticationRequestHeaderName))
            {
                _httpClient.DefaultRequestHeaders.Remove(AuthenticationRequestHeaderName);
            }

            _httpClient.DefaultRequestHeaders.Add(AuthenticationRequestHeaderName, token);
        }
    }
}