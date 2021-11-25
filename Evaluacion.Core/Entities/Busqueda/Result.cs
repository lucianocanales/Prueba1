namespace Evaluacion.Core.Entities.Busqueda
{
    public class Result
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public Seller seller { get; set; }
        public float price { get; set; }
        public string permalink { get; set; }
    }


}
