namespace WeatherAPP.APIClient.Models{ 

    public class Metric
    {
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
        public string Phrase { get; set; }
    }

}