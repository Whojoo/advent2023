using AdventOfCode2023.RequestBinders;

namespace AdventOfCode2023.Utils;

public abstract class PlainTextEndpoint<TResponse> : Endpoint<string, TResponse>
{
    protected abstract string Path { get; }
    
    public sealed override void Configure()
    {
        Post(Path);
        AllowAnonymous();
        Options(x => x.Accepts<string>("text/plain"));
        RequestBinder(new PlainTextRequestBinder());
    }

    public sealed override Task HandleAsync(string req, CancellationToken ct)
    {
        var response = ExecuteEndpoint(req);
        return SendAsync(response, cancellation: ct);
    }

    protected abstract TResponse ExecuteEndpoint(string input);
}