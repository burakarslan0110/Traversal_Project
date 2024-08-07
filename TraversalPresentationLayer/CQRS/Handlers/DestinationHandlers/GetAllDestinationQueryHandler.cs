using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TraversalPresentationLayer.CQRS.Queries.DestinationQueries;
using TraversalPresentationLayer.CQRS.Results.DestinationResults;

namespace TraversalPresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            this._context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                ID = x.DestinationID,
                City = x.City,
                Capacity = x.Capacity,
                DayNight = x.DayNight,
                Price = x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
