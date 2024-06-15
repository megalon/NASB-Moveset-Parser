using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SAMapAnimationSimple : StateAction, IBulkSerializer
    {
        public string AnimId;
        public bool RootAnim;
        public MapPoint[] MapPoints;

        public SAMapAnimationSimple() { }

        private void EnsureStuff()
        {
            MapPoints ??= new MapPoint[0];

            for (int i = 0; i < MapPoints.Length; i++)
            {
                MapPoints[i] ??= new MapPoint();
            }
        }

        public new static SAMapAnimationSimple ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            var mapAnimationSimple = new SAMapAnimationSimple
            {
                TID = TypeId.SAMapAnimationSimple,
                AnimId = reader.GetNextString(),
                RootAnim = reader.GetNextInt() > 0
            };

            var mapPointsCount = reader.GetNextInt();
            mapAnimationSimple.MapPoints = new MapPoint[mapPointsCount];

            for (int i = 0; i < mapPointsCount; i++)
            {
                mapAnimationSimple.MapPoints[i] = new MapPoint(reader);
            }

            return mapAnimationSimple;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(75);
            writer.AddInt(0);

            writer.AddString(AnimId);
            writer.AddInt(RootAnim ? 7 : 0);

            writer.AddInt(MapPoints.Length);

            for (int i = 0; i < MapPoints.Length; i++)
            {
                MapPoints[i].WriteSerial(writer);
            }
        }

        public class MapPoint : IBulkSerializer
        {
            public FloatSourceContainer OffsetFrame;
            public FloatSourceContainer AnimFrame;

            public MapPoint() { }

            private void EnsureStuff()
            {
                OffsetFrame ??= new FloatSourceContainer(new FloatSource());
                AnimFrame ??= new FloatSourceContainer(new FloatSource());
            }

            public MapPoint(Reader reader)
            {
                reader.GetNextInt();

                OffsetFrame = FloatSourceContainer.ReadSerial(reader);
                AnimFrame = FloatSourceContainer.ReadSerial(reader);
            }

            public void WriteSerial(Writer writer)
            {
                EnsureStuff();

                writer.AddInt(0);

                OffsetFrame.WriteSerial(writer);
                AnimFrame.WriteSerial(writer);
            }
        }
    }
}
