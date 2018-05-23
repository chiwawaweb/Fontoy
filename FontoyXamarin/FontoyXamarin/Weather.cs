using System;
using System.Collections.Generic;
using System.Text;

namespace FontoyXamarin
{
    public class Weather
    {
        // Because labels bind to these values, set them to an empty string to
        // ensure that the label appears on all platforms by default.
        public string Title { get; set; } = " ";
        public string Temperature { get; set; } = " ";
        public string Wind { get; set; } = " ";
        public string Humidity { get; set; } = " ";
        public string Visibility { get; set; } = " ";
        public string Sunrise { get; set; } = " ";
        public string Sunset { get; set; } = " ";


        public string TemperatureNow { get; set; } = " ";
        public string PressionNow { get; set; } = " ";
        public string PluieNow { get; set; } = " ";
        public string VentVitesseNow { get; set; } = " ";
        public string VentDirectionNow { get; set; } = " ";
        public string RisqueNeigeNow { get; set; } = " ";
        public string NebulositeNow { get; set; } = " ";

        
    }
}
