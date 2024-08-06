namespace TraversalPresentationLayer.Models
{
    public class ExchangeRatesViewModel
    {

        public  string base_currency { get; set; }
        public  string base_currency_date { get; set; }
        public  Exchange_Rates[] exchange_rates { get; set; }
        public class Exchange_Rates
        {
            public required string exchange_rate_buy { get; set; }
            public required string currency { get; set; }
        }

    }
}
