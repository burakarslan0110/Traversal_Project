namespace TraversalPresentationLayer.CQRS.Commands.DestinationCommands
{
    public class DeleteDestinationCommand
    {
        public int ID { get; set; }

        public DeleteDestinationCommand(int id)
        {
            ID = id;
        }
    }
}
