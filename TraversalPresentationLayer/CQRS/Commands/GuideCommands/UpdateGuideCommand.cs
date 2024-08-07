using MediatR;

namespace TraversalPresentationLayer.CQRS.Commands.GuideCommands
{
    public class UpdateGuideCommand : IRequest
    {
        public int GuideID { get; set; }
        public string GuideName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
