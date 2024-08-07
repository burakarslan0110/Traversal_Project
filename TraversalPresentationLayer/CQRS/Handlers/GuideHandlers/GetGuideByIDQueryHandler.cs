using DataAccessLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using TraversalPresentationLayer.CQRS.Queries.GuideQueries;
using TraversalPresentationLayer.CQRS.Results.GuideResults;

namespace TraversalPresentationLayer.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.ID);
            return new GetGuideByIDQueryResult
            {
                GuideID = values.GuideID,
                Description = values.Description,
                GuideName = values.GuideName,
                Image = values.Image,
            };
        }
    }
}
