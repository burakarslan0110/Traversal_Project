using MediatR;

namespace TraversalPresentationLayer.CQRS.Commands.GuideCommands
{
    public class DeleteGuideCommand : IRequest
    {
        public int ID { get; set; }

        public DeleteGuideCommand(int ıD)
        {
            ID = ıD;
        }
    }
}
