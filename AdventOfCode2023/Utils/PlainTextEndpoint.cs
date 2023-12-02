using AdventOfCode2023.RequestBinders;

namespace AdventOfCode2023.Utils;

public abstract class PlainTextEndpoint<TResponse> : Endpoint<string, TResponse>
{
    public sealed override void Configure()
    {
        CustomConfigure();
        AllowAnonymous();
        Options(x => x.Accepts<string>("text/plain"));
        RequestBinder(new PlainTextRequestBinder());
    }

    protected abstract void CustomConfigure();
}