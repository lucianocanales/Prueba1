namespace Evaluacion.Core.Entities
{
    public class Countries
    {
        public string id { get; set; }
        public string name { get; set; }
        public string locale { get; set; }
        public string currency_id { get; set; }
        public string decimal_separator { get; set; }
        public string thousands_separator { get; set; }
        public string time_zone { get; set; }
        public Geo_information geo_information { get; set; }
        public States[] states { get; set; }
    }
}
