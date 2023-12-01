namespace AdventOfCode2023.RequestBinders;

public class PlainTextRequestBinder : RequestBinder<string>
{
    public override async ValueTask<string> BindAsync(BinderContext ctx, CancellationToken cancellation)
    {
        using var reader = new StreamReader(ctx.HttpContext.Request.Body);
        return await reader.ReadToEndAsync(cancellation);
    }
}