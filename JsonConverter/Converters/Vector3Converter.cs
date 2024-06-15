using MovesetParser.Unity;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace JsonConverter.Converters
{
    public class Vector3Converter : JsonConverter<Vector3>
    {
        public override Vector3 ReadJson(JsonReader reader, Type objectType, [AllowNull] Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonException();

            var result = Vector3.zero;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                    return result;

                var propertyName = reader.Value as string;

                switch (propertyName)
                {
                    case "x":
                        result.x = (float)reader.ReadAsDouble();
                        break;
                    case "y":
                        result.y = (float)reader.ReadAsDouble();
                        break;
                    case "z":
                        result.z = (float)reader.ReadAsDouble();
                        break;
                }
            }
            throw new JsonException();
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] Vector3 value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("x");
            writer.WriteValue(value.x);

            writer.WritePropertyName("y");
            writer.WriteValue(value.y);

            writer.WritePropertyName("z");
            writer.WriteValue(value.z);

            writer.WriteEndObject();
        }
    }
}
