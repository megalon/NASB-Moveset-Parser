using MovesetParser.FloatSources;
using MovesetParser.StateActions;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace JsonConverter.Converters
{
    public static class Converter
    {
        internal static U ReadJson<T, U>(JsonReader reader, JsonSerializer serializer, FieldInfo tidInfo, Func<T, U> creator) where T : struct
        {
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonException();

            reader.Read();
            var typeIdName = reader.Value as string;

            if (typeIdName != tidInfo.Name)
                throw new JsonException();

            if (!Enum.TryParse<T>(reader.ReadAsString(), false, out var tid))
                throw new JsonException();

            var result = creator(tid);
            tidInfo.SetValue(result, tid);
            var fields = result.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                    return result;

                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var fieldName = reader.Value as string;
                    reader.Read();
                    var match = fields.FirstOrDefault(field => field.Name == fieldName);

                    if (match != null)
                        match.SetValue(result, serializer.Deserialize(reader, match.FieldType));
                    else
                        throw new JsonException();
                }
            }
            throw new JsonException();
        }

        internal static void WriteJson<T>(JsonWriter writer, [AllowNull] T value, JsonSerializer serializer, FieldInfo tidInfo)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(tidInfo.Name);
            writer.WriteValue(tidInfo.GetValue(value).ToString());

            if (value.GetType() == typeof(StateAction))
            {
                writer.WriteEndObject();
            }
            else
            {
                foreach (var field in value.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (field.Name == tidInfo.Name)
                        continue;


                    if (field.Name == "Value" && 
                        field.GetValue(value).GetType() == typeof(float) && 
                        (float)field.GetValue(value) == 0f &&
                        value.GetType().IsSubclassOf(typeof(FloatSource)))
                    {
                        continue;
                    }

                    writer.WritePropertyName(field.Name);
                    serializer.Serialize(writer, field.GetValue(value), field.FieldType);
                }

                writer.WriteEndObject();
            }
        }
    }
}
