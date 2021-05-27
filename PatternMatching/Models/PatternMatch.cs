using Newtonsoft.Json;
using PatternMatching.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatternMatching.Models
{
    public class PatternMatch 
    {
        [JsonProperty(Order = 0)]
        public string Text { get; set; }
        [JsonProperty(Order = 1)]
        public string SubText { get; set; }       
        [NoMap]
        [JsonProperty(Order = 2)]
        public List<int> StartPositionOfMatchedPatternOccurences;
    }
}