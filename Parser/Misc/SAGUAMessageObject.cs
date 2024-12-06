using MovesetParser.BulkSerialize;
using MovesetParser.ObjectSources;
using System.Collections.Generic;

namespace MovesetParser.Misc
{
    [Serializable]
    public class SAGUAMessageObject : IBulkSerializer
    {
        public string PlainMessage;
        public List<MsgDynamic> Messages = new List<MsgDynamic>();

        public SAGUAMessageObject() { }

        public static SAGUAMessageObject ReadSerial(Reader reader)
        {
            reader.GetNextInt();

            SAGUAMessageObject sAGUAMessageObject = new SAGUAMessageObject
            {
                PlainMessage = reader.GetNextString()
            };

            var messageCount = reader.GetNextInt();
            for (int i = 0; i < messageCount; i++)
            {
                sAGUAMessageObject.Messages.Add(MsgDynamic.ReadSerial(reader));
            }

            return sAGUAMessageObject;
        }

        public void WriteSerial(Writer writer)
        {
            writer.AddInt(0);

            writer.AddString(PlainMessage);

            var count = Messages.Count;
            writer.AddInt(count);

            for (int i = 0; i < count; i++)
            {
                Messages[i] ??= new MsgDynamic();
                Messages[i].WriteSerial(writer);
            }
        }

    [Serializable]
    public class MsgDynamic : IBulkSerializer
        {
            public string Id = string.Empty;
            public ObjectSourceContainer ObjectSourceContainer;

            public MsgDynamic() { }

            public static MsgDynamic ReadSerial(Reader reader)
            {
                reader.GetNextInt();

                return new MsgDynamic
                {
                    Id = reader.GetNextString(),
                    ObjectSourceContainer = ObjectSourceContainer.ReadSerial(reader)
                };
            }

            public void WriteSerial(Writer writer)
            {
                writer.AddInt(0);
                writer.AddString(Id);

                ObjectSourceContainer ??= new ObjectSourceContainer();
                ObjectSourceContainer.WriteSerial(writer);
            }
        }
    }
}
