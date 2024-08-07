using DataAccessLayer.Concrete;
using MediatR;
using TraversalPresentationLayer.CQRS.Commands.GuideCommands;

namespace TraversalPresentationLayer.CQRS.Handlers.GuideHandlers
{
    public class DeleteGuideCommandHandler : IRequestHandler<DeleteGuideCommand>
    {
        private readonly Context _context;

        public DeleteGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGuideCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.ID);
            _context.Guides.Remove(values);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
