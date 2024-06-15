using MovesetParser.ObjectSources;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using static MovesetParser.ObjectSources.ObjectSource;

namespace JsonConverter.Converters
{
    public class ObjectSourceConverter : JsonConverter<ObjectSource>
    {
        private static readonly FieldInfo tidInfo = typeof(ObjectSource).GetField(nameof(ObjectSource.TID));

        public override ObjectSource ReadJson(JsonReader reader, Type objectType, [AllowNull] ObjectSource existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, ObjectSource>(reader, serializer, tidInfo, res => res switch
            {
                TypeId.OSFloat => new OSFloat(),
                TypeId.OSVector2 => new OSVector2(),
                TypeId.ObjectSource => new ObjectSource(),
                _ => throw new JsonException(),
            });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] ObjectSource value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo);
        }
    }
}
