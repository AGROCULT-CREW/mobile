using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Unity.VisualScripting;

namespace Assets.Models
{
    [Serializable]
    public class CultureInput
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Name = "average_weight_thousand_grains", Order = 3)]
        public int AverageWeightThousandGrains { get; set; }
    }
}