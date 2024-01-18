using MediatR;

namespace ECommerce.Application;

public record Command(int Id, string Name) : IRequest<Response>;
public record Response(string Name, DateTime DateTime);

public class TestHandler : IRequestHandler<Command, Response>
{
    public Task<Response> Handle(Command command, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Response(command.Name, DateTime.Now));
    }
}