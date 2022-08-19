using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLibraryTest.StepDefinitions
{
    public class CreateBookBadRequestModel
    {
        [JsonProperty ("type")]
        public string Type { get; set; }

        [JsonProperty ("title")]
        public string Title { get; set; }

        [JsonProperty ("status")]
        public int Status { get; set; }

        [JsonProperty ("traceId")]
        public string TraceId { get; set; }

        [JsonProperty ("errors")]
        public BadRequestErrors Errors { get; set; }
    }
}
