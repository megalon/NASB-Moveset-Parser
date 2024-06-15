using MovesetParser.Jumps;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using static MovesetParser.Jumps.Jump;

namespace JsonConverter.Converters
{
    public class JumpConverter : JsonConverter<Jump>
    {
        private static readonly FieldInfo tidInfo = typeof(Jump).GetField(nameof(Jump.TID));

        public override Jump ReadJson(JsonReader reader, Type objectType, [AllowNull] Jump existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, Jump>(reader, serializer, tidInfo, res => res switch
            {
                TypeId.HeightJump => new HeightJump(),
                TypeId.HoldJump => new HoldJump(),
                TypeId.AirDashJump => new AirDashJump(),
                TypeId.KnockbackJump => new KnockbackJump(),
                TypeId.Jump => new Jump(),
                _ => throw new JsonException(),
            });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] Jump value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo);
        }
    }
}
