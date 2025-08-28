using BookServiceGRPC;
using Grpc.Net.Client;
using LibraryGRPC.Abstractions;
using Microsoft.Extensions.Options;
using System.ComponentModel.Design;

namespace LibraryGRPC.Provider;

public class BookManagerProvider : IBookManagerProvider
{
    private readonly BookManagerOption options;

    public BookManagerProvider(IOptions<BookManagerOption> options)
    {
        this.options = options.Value;
    }
    public async Task<string> SayHello()
    {
        var channel = GrpcChannel.ForAddress(options.Url);
        var _client = new Greeter.GreeterClient(channel);

        var request = new HelloRequest { Name = "sara" };
        var response = await _client.SayHelloAsync(request);



        return response.ToString();
    }

    public async Task<string> SaySara()
    {
        var channel = GrpcChannel.ForAddress(options.Url);
        var _client = new Greeter.GreeterClient(channel);

        var request = new SaraRequest { Name = "sara" };
        var response = await _client.SaySaraAsync(request);



        return response.ToString();
    }
}

public class BookManagerProvider2 : IBookManagerProvider
{
    private readonly Greeter.GreeterClient client;

    public BookManagerProvider2(Greeter.GreeterClient client)
    {
        this.client = client;
    }
    public async Task<string> SayHello()
    {
        var request = new HelloRequest { Name = "sara" };
        var response = await client.SayHelloAsync(request);

        return response.ToString();
    }

    public async Task<string> SaySara()
    {
        var request = new SaraRequest { Name = "sara" };
        var response = await client.SaySaraAsync(request);

        return response.ToString();
    }
}