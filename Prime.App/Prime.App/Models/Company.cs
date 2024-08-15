using Newtonsoft.Json;

namespace Prime.App.Models
{
    public class Company
    {
        //public int ID { get; set; }
        //public string? Name { get; set; }
        //public string? Address { get; set; }
        //public string? PropName { get; set; }
        //public string? PropValue { get; set; }

        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        // This dictionary holds dynamic properties
        public Dictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();

        // Converts AdditionalProperties to a JSON string
        public string AdditionalPropertiesJson
        {
            get => JsonConvert.SerializeObject(AdditionalProperties);
            set => AdditionalProperties = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);
        }
    }
}
