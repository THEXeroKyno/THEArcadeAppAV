using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace THEArcadeAppAV.Models.APIModels;

public class WeatherApiReasonse
{
        [JsonPropertyName("request")] 
        public WeatherApiReasonseRequest Request { get; set; }

        [JsonPropertyName("location")]
        public WeatherApiReasonseLocation Location { get; set; }

        [JsonPropertyName("current")]
        public WeatherApiReasonseCurrent Current { get; set; }
}

public class WeatherApiReasonseRequest
{
        public string Type { get; set; }

        public string Query { get; set; }
        public string Language { get; set; }
        public string Unit { get; set; }
}

public class WeatherApiReasonseLocation
{
        public string Name { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }
        public string Lat { get; set; }

        public string Lon { get; set; }
        public string TimezoneId { get; set; }
        public string Localtime { get; set; }
        public long LocaltimeEpoch { get; set; }

        public string UtcOffset { get; set; }
}

public class WeatherApiReasonseCurrent
{

        public int Temperature { get; set; }
        public int WeatherCode { get; set; }
        public string[] weather_icons { get; set; }
        public string[] weather_descriptions { get; set; }

        public int feelslike {get; set;}

        public int humidity {get; set;}
}