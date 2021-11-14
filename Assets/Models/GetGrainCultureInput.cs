using Newtonsoft.Json;

namespace Assets.Models
{
    public class GetGrainCultureInput
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty(PropertyName = "average_weight_thousand_grains")]
        public double AverageWeightThousandGrains { get; set; }
    }
}