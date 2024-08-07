using MediatR;

namespace TraversalPresentationLayer.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand : IRequest 
    {
        public string GuideName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
