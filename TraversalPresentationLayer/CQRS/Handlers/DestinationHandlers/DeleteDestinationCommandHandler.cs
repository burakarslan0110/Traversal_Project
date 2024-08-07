using DataAccessLayer.Concrete;
using TraversalPresentationLayer.CQRS.Commands.DestinationCommands;

namespace TraversalPresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class DeleteDestinationCommandHandler
    {
        private readonly Context _context;

        public DeleteDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(DeleteDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.ID);
            _context.Destinations.Remove(values);
            _context.SaveChanges();
        }
    }
}
