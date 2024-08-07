using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraversalPresentationLayer.CQRS.Queries.GuideQueries;
using TraversalPresentationLayer.CQRS.Results.GuideResults;

namespace TraversalPresentationLayer.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideID = x.GuideID,
                GuideName = x.GuideName,
                Description = x.Description,
                Image = x.Image,
            }).AsNoTracking().ToListAsync();
        }
    }
}
