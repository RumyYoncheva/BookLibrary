using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryTest.StepDefinitions
{
    public class ResponseClass
    {
        [JsonProperty ("token")]
        public string Token { get; set; }

        [JsonProperty ("expirationDate")]
        public string ExpirationDate { get; set; }
    }
}
