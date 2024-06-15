using MovesetParser.FloatSources;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using static MovesetParser.FloatSources.FloatSource;

namespace JsonConverter.Converters
{
    public class FloatSourceConverter : JsonConverter<FloatSource>
    {
        private static readonly FieldInfo tidInfo = typeof(FloatSource).GetField(nameof(FloatSource.TID));

        public override FloatSource ReadJson(JsonReader reader, Type objectType, [AllowNull] FloatSource existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, FloatSource>(reader, serializer, tidInfo, res => res switch
            {
                TypeId.FSAgent => new FSAgent(),
                TypeId.FSBones => new FSBones(),
                TypeId.FSAttack => new FSAttack(),
                TypeId.FSFrame => new FSFrame(),
                TypeId.FSInput => new FSInput(),
                TypeId.FSFunc => new FSFunc(),
                TypeId.FSMovement => new FSMovement(),
                TypeId.FSCombat => new FSCombat(),
                TypeId.FSGrabs => new FSGrabs(),
                TypeId.FSData => new FSData(),
                TypeId.FSScratch => new FSScratch(),
                TypeId.FSAnim => new FSAnim(),
                TypeId.FSSpeed => new FSSpeed(),
                TypeId.FSPhysics => new FSPhysics(),
                TypeId.FSCollision => new FSCollision(),
                TypeId.FSTimer => new FSTimer(),
                TypeId.FSLag => new FSLag(),
                TypeId.FSEffects => new FSEffects(),
                TypeId.FSColors => new FSColors(),
                TypeId.FSOnHit => new FSOnHit(),
                TypeId.FSRandom => new FSRandom(),
                TypeId.FSCameraInfo => new FSCameraInfo(),
                TypeId.FSSports => new FSSports(),
                TypeId.FSVector2Mag => new FSVector2Mag(),
                TypeId.FSCPUHelp => new FSCPUHelp(),
                TypeId.FSItem => new FSItem(),
                TypeId.FSMode => new FSMode(),
                TypeId.FSJumps => new FSJumps(),
                TypeId.FSRootAnim => new FSRootAnim(),
                TypeId.FloatSource => new FloatSource(),
                _ => throw new JsonException(),
            });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] FloatSource value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo);
        }
    }
}
