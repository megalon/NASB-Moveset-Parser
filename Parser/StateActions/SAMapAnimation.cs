using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SAMapAnimation : StateAction, IBulkSerializer
    {
        public MapPoint[] MapPoints;

        public SAMapAnimation() { }

        private void EnsureStuff()
        {
            MapPoints ??= new MapPoint[0];

            for (int i = 0; i < MapPoints.Length; i++)
            {
                MapPoints[i] ??= new MapPoint();
            }
        }

        public new static SAMapAnimation ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            var mapAnimation = new SAMapAnimation()
            {
                TID = TypeId.SAMapAnimation
            };

            int MapPointsLength = reader.GetNextInt();
            mapAnimation.MapPoints = new MapPoint[MapPointsLength];

            for (int i = 0; i < MapPointsLength; i++)
            {
                mapAnimation.MapPoints[i] = new MapPoint(reader);
            }

            return mapAnimation;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(55);
            writer.AddInt(0);

            writer.AddInt(MapPoints.Length);

            for (int i = 0; i < MapPoints.Length; i++)
            {
                MapPoints[i].WriteSerial(writer);
            }
        }

        public class MapPoint : IBulkSerializer
        {
            public FloatSourceContainer AtFrame;
            public FloatSourceContainer Frames;
            public string AnimId;
            public bool RootAnim;
            public FloatSourceContainer StartAnimFrame;
            public FloatSourceContainer EndAnimFrame;

            public MapPoint() { }

            private void EnsureStuff()
            {
                AtFrame ??= new FloatSourceContainer(new FloatSource());
                Frames ??= new FloatSourceContainer(new FloatSource());
                StartAnimFrame ??= new FloatSourceContainer(new FloatSource());
                EndAnimFrame ??= new FloatSourceContainer(new FloatSource());
            }

            
            public MapPoint(Reader reader)
            {
                reader.GetNextInt();

                RootAnim = reader.GetNextInt() > 0;
                AnimId = reader.GetNextString();
                AtFrame = FloatSourceContainer.ReadSerial(reader);
                Frames = FloatSourceContainer.ReadSerial(reader);
                StartAnimFrame = FloatSourceContainer.ReadSerial(reader);
                EndAnimFrame = FloatSourceContainer.ReadSerial(reader);
            }
            public void WriteSerial(Writer writer)
            {
                EnsureStuff();

                writer.AddInt(0);

                writer.AddInt(RootAnim ? 7 : 0);
                writer.AddString(AnimId);
                AtFrame.WriteSerial(writer);
                Frames.WriteSerial(writer);
                StartAnimFrame.WriteSerial(writer);
                EndAnimFrame.WriteSerial(writer);
            }


            
        }
    }
}
