﻿namespace TraversalPresentationLayer.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public string Capacity { get; set; }

        public bool Status { get; set; }
    }
}
