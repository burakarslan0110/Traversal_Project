using DataAccessLayer.Concrete;
using MediatR;
using TraversalPresentationLayer.CQRS.Commands.GuideCommands;
using TraversalPresentationLayer.CQRS.Queries.GuideQueries;
using TraversalPresentationLayer.CQRS.Results.GuideResults;

namespace TraversalPresentationLayer.CQRS.Handlers.GuideHandlers
{
    public class UpdateGuideCommandHandler : IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;

        public UpdateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.GuideID);
            values.GuideName = request.GuideName;
            values.Description = request.Description;
            values.Image = request.Image;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
