using Newtonsoft.Json;

namespace SPP2.Serialization
{
    class JsonSerializer : ISerializer
    {
        private JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            Formatting = Formatting.Indented,
        };
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonSettings);
        }
    }
}
