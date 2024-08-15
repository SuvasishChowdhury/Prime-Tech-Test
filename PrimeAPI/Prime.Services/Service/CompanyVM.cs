using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Services.Service
{
    public class CompanyVM
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        // This dictionary holds dynamic properties
        public Dictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
        public string AdditionalPropertiesJson
        {
            get
            {
                if (AdditionalProperties != null && AdditionalProperties.Any())
                {
                    return JsonConvert.SerializeObject(AdditionalProperties, Formatting.Indented);
                }
                return "{}";
            }
            set
            {
                try
                {
                    // Attempt to deserialize directly to a dictionary
                    AdditionalProperties = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);
                }
                catch (JsonSerializationException)
                {
                    // Handle cases where value might be a string of JSON
                    var jsonString = JsonConvert.DeserializeObject<string>(value);
                    AdditionalProperties = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                }
            }
        }

    }
}
