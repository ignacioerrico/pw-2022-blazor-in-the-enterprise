using IdentityModel.Client;

namespace ProgrammersWeek.TalkManager.BlazorUi.Services
{
    public class RefreshTokenService
    {
        private readonly TokenService _token;
        private readonly HttpClient _httpClient;

        public RefreshTokenService(TokenService token, HttpClient httpClient)
        {
            _token = token;
            _httpClient = httpClient;
        }

        public async Task<string> RetrieveAccessTokenAsync()
        {
            // Don't wait till the last moment to get a refresh token; get it 10 seconds before expiration.
            if (DateTime.UtcNow < _token.ExpiresAt.AddSeconds(-10).ToUniversalTime())
            {
                return _token.AccessToken!;
            }

            var discoveryDocument = await _httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");
            var refreshTokenRequest = new RefreshTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "talkmanagerblazorserver",
                ClientSecret = "secret",
                RefreshToken = _token.RefreshToken
            };

            var refreshToken = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

            _token.AccessToken = refreshToken.AccessToken;
            _token.RefreshToken = refreshToken.RefreshToken;
            _token.ExpiresAt = DateTime.UtcNow.AddSeconds(refreshToken.ExpiresIn);

            return _token.AccessToken;
        }

    }
}
