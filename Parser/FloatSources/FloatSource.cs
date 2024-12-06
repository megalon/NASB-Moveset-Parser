using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FloatSource : IBulkSerializer
    {
        public TypeId TID = 0;

        public float Value = 0f;

        public FloatSource() { }

        public FloatSource(float value)
        {
            Value = value;
        }

        private static FloatSource ReadSerialBase(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();
            return new FloatSource
            {
                Value = reader.GetNextFloat()
            };
        }

        public static FloatSource ReadSerial(Reader reader)
        {
            var typeId = (TypeId)reader.PeekNextInt();
            switch (typeId)
            {
                case TypeId.FloatSource:
                    return ReadSerialBase(reader);
                case TypeId.FSAgent:
                    return FSAgent.ReadSerial(reader);
                case TypeId.FSBones:
                    return FSBones.ReadSerial(reader);
                case TypeId.FSAttack:
                    return FSAttack.ReadSerial(reader);
                case TypeId.FSFrame:
                    return FSFrame.ReadSerial(reader);
                case TypeId.FSInput:
                    return FSInput.ReadSerial(reader);
                case TypeId.FSFunc:
                    return FSFunc.ReadSerial(reader);
                case TypeId.FSMovement:
                    return FSMovement.ReadSerial(reader);
                case TypeId.FSCombat:
                    return FSCombat.ReadSerial(reader);
                case TypeId.FSGrabs:
                    return FSGrabs.ReadSerial(reader);
                case TypeId.FSData:
                    return FSData.ReadSerial(reader);
                case TypeId.FSScratch:
                    return FSScratch.ReadSerial(reader);
                case TypeId.FSAnim:
                    return FSAnim.ReadSerial(reader);
                case TypeId.FSSpeed:
                    return FSSpeed.ReadSerial(reader);
                case TypeId.FSPhysics:
                    return FSPhysics.ReadSerial(reader);
                case TypeId.FSCollision:
                    return FSCollision.ReadSerial(reader);
                case TypeId.FSTimer:
                    return FSTimer.ReadSerial(reader);
                case TypeId.FSLag:
                    return FSLag.ReadSerial(reader);
                case TypeId.FSEffects:
                    return FSEffects.ReadSerial(reader);
                case TypeId.FSColors:
                    return FSColors.ReadSerial(reader);
                case TypeId.FSOnHit:
                    return FSOnHit.ReadSerial(reader);
                case TypeId.FSRandom:
                    return FSRandom.ReadSerial(reader);
                case TypeId.FSCameraInfo:
                    return FSCameraInfo.ReadSerial(reader);
                case TypeId.FSSports:
                    return FSSports.ReadSerial(reader);
                case TypeId.FSVector2Mag:
                    return FSVector2Mag.ReadSerial(reader);
                case TypeId.FSCPUHelp:
                    return FSCPUHelp.ReadSerial(reader);
                case TypeId.FSItem:
                    return FSItem.ReadSerial(reader);
                case TypeId.FSMode:
                    return FSMode.ReadSerial(reader);
                case TypeId.FSJumps:
                    return FSJumps.ReadSerial(reader);
                case TypeId.FSRootAnim:
                    return FSRootAnim.ReadSerial(reader);
                case TypeId.FSLastAtk:
                    return FSLastAtk.ReadSerial(reader);
                default:
                    throw new ReadException(reader, $"Unimplemented StateAction serialization for id: {typeId}");
            }
        }

        public virtual void WriteSerial(Writer writer)
        {
            writer.AddInt(0);
            writer.AddInt(0);
            writer.AddFloat(Value);
        }

        public enum TypeId
        {
            FloatSource,
            FSAgent,
            FSBones,
            FSAttack,
            FSFrame,
            FSInput,
            FSFunc,
            FSMovement,
            FSCombat,
            FSGrabs,
            FSData,
            FSScratch,
            FSAnim,
            FSSpeed,
            FSPhysics,
            FSCollision,
            FSTimer,
            FSLag,
            FSEffects,
            FSColors,
            FSOnHit,
            FSRandom,
            FSCameraInfo,
            FSSports,
            FSVector2Mag,
            FSCPUHelp,
            FSItem,
            FSMode,
            FSJumps,
            FSRootAnim,
            FSLastAtk
        }
    }
}
