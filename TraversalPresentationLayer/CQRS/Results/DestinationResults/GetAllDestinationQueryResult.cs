namespace TraversalPresentationLayer.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int ID { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public string Capacity { get; set; }
        public string DayNight { get; set; }
    }
}
