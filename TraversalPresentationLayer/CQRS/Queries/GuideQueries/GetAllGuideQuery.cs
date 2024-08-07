using MediatR;
using TraversalPresentationLayer.CQRS.Results.GuideResults;

namespace TraversalPresentationLayer.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
