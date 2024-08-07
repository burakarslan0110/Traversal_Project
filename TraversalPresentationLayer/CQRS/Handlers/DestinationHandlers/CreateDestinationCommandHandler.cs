using DataAccessLayer.Concrete;
using TraversalPresentationLayer.CQRS.Commands.DestinationCommands;

namespace TraversalPresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new EntityLayer.Concrete.Destination
            {
                City = command.City,
                Price = command.Price,
                DayNight = command.DayNight,
                Capacity = command.Capacity,
                Status = true
            });
            _context.SaveChanges();
        }
    }
}
