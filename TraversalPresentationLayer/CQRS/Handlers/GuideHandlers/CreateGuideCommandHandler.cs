using DataAccessLayer.Concrete;
using MediatR;
using TraversalPresentationLayer.CQRS.Commands.GuideCommands;

namespace TraversalPresentationLayer.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new EntityLayer.Concrete.Guide
            {
                GuideName = request.GuideName,
                Description = request.Description,
                Image = request.Image
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
