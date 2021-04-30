# gotify-csharpclient
This is a simple C# client to use when interacting with a [Gotify Server](https://github.com/gotify/server).

The client is generated using [NSwag](https://github.com/RicoSuter/NSwag) from the [Gotify Server API Documentation](https://gotify.net/api-docs)

![package workflow](https://github.com/panmau/gotify-csharpclient/actions/workflows/nuget-publish.yml/badge.svg)

## Installation
`dotnet add package Gotify.Client`

## Usage

It is recommended to use the client using [typed clients and the HttpClientFactory](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#how-to-use-typed-clients-with-ihttpclientfactory):
```
services.AddHttpClient<IGotifyClient, GotifyClient>(client =>
{
  client.BaseAddress = new Uri(configuration["BaseUrl"]);
});
```

### Authentication
For authentication Gotify uses the "X-Gotify-Key" header. You can either add this header when registering your typed client:
```
services.AddHttpClient<IGotifyClient, GotifyClient>(client =>
{
  client.BaseAddress = new Uri(configuration["BaseUrl"]);
  client.DefaultRequestHeaders.Add("X-Gotify-Key", configuration["Token"]);
});
```

Alternatively you can also add this header after initialization of the client:
```
private readonly IGotifyClient _client;

public MyClass(IGotifyClient client) {
  _client = client;
}

public async Task SomeMethod(string token) {
  // If a header is already set, this method will recreate the header
  _client.SetAuthenticationRequestHeader(token);
  // And then for example:
  await gotifyClient.GetAppsAsync()
}
```
