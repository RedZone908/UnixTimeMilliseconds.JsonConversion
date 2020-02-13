using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace UnixTimeMilliseconds.JsonConversion
{
    /// <summary>
    /// Allows converting between JSON-embedded millisecond-encoded Unix date times and .Net's DateTimeOffset type.
    /// </summary>
    public class UnixTimeMillisecondsToDateTimeOffsetJsonConverter : JsonConverter
    {
        //this class borrows some code from StackOverflow:
        //https://stackoverflow.com/questions/19971494/how-to-deserialize-a-unix-timestamp-%CE%BCs-to-a-datetime-from-json

        public override bool CanConvert(Type objectType)
            => objectType == typeof(DateTimeOffset);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;
            return DateTimeOffset.FromUnixTimeMilliseconds((long)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = (DateTimeOffset)value;
            var unixTime = date.ToUnixTimeMilliseconds();
            writer.WriteRawValue(unixTime.ToString());
        }
    }
}
