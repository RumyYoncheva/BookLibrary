using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryTest.StepDefinitions
{
    public class BadRequestErrors
    {
        [JsonProperty ("Title")]
        public List<string> Title { get; set; }
    }
}
