using MovesetParser.CheckThings;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using static MovesetParser.CheckThings.CheckThing;

namespace JsonConverter.Converters
{
    public class CheckThingConverter : JsonConverter<CheckThing>
    {
        private static readonly FieldInfo tidInfo = typeof(CheckThing).GetField(nameof(CheckThing.TID));

        public override CheckThing ReadJson(JsonReader reader, Type objectType, [AllowNull] CheckThing existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, CheckThing>(reader, serializer, tidInfo, res => res switch
            {
                TypeId.CTMultiple => new CTMultiple(),
                TypeId.CTCompareFloat => new CTCompareFloat(),
                TypeId.CTDoubleTap => new CTDoubleTap(),
                TypeId.CTInput => new CTInput(),
                TypeId.CTInputSeries => new CTInputSeries(),
                TypeId.CTCheckTech => new CTCheckTech(),
                TypeId.CTGrab => new CTGrab(),
                TypeId.CTGrabbedAgent => new CTGrabbedAgent(),
                TypeId.CTSkin => new CTSkin(),
                TypeId.CTMove => new CTMove(),
                TypeId.CheckThing => new CheckThing(),
                _ => throw new JsonException(),
            });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] CheckThing value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo);
        }
    }
}
