using DataAccessLayer.Concrete;
using TraversalPresentationLayer.CQRS.Queries.DestinationQueries;
using TraversalPresentationLayer.CQRS.Results.DestinationResults;

namespace TraversalPresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price,
                Capacity = values.Capacity, 
                
            };
        }
    }
}
