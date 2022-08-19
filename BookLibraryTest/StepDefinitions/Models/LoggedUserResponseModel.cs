using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryTest.StepDefinitions
{
    public class LoggedUserResponseModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }
    }
}
