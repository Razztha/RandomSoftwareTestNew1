using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MockAPIService.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(MyDateTimeConverter))]
        public DateTime CreatedTime { get; set; }
        public string AuthorName { get; set; }
        public int TotalLikes { get; set; }
    }

    //public class MicrosecondEpochConverter : DateTimeConverterBase
    //{
    //    private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.Value == null) { return null; }
    //        var v = _epoch.AddMilliseconds((long)reader.Value / 1000d);
    //        return _epoch.AddMilliseconds((long)reader.Value / 1000d);
    //    }
    //}

    public class MyDateTimeConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var t = (long)reader.Value;
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(t);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
