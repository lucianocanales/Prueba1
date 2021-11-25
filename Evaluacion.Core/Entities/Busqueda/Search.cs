using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluacion.Core.Entities.Busqueda
{
    public class Search
    {
        public string site_id { get; set; }
        public string country_default_time_zone { get; set; }
        public string query { get; set; }
        public Paging paging { get; set; }
        public Result[] results { get; set; }
        public Sort sort { get; set; }
        public Available_Sorts[] available_sorts { get; set; }
        public Filter[] filters { get; set; }
        public Available_Filters[] available_filters { get; set; }
    }

}
