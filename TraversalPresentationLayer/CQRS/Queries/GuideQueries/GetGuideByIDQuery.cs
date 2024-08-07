using MediatR;
using TraversalPresentationLayer.CQRS.Results.GuideResults;

namespace TraversalPresentationLayer.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public int ID { get; set; }

        public GetGuideByIDQuery(int ıD)
        {
            ID = ıD;
        }
    }
}
