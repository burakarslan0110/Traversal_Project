using DataAccessLayer.Concrete;
using TraversalPresentationLayer.CQRS.Commands.DestinationCommands;

namespace TraversalPresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationID);
            values.Capacity = command.Capacity;
            values.DayNight = command.DayNight;
            values.Price = command.Price;
            values.City = command.City;
            values.Status = true;
            _context.SaveChanges();
        }
    }
}
