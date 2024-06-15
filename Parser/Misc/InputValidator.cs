using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.Misc
{
    public partial class InputValidator : IBulkSerializer
    {
        public InputType InputType = InputType.Attack;
        public bool RawX;
        public FloatSourceContainer FloatValue = new(new FloatSource());
        public CtrlSeg Segment;
        public FloatCompare FloatCompare;
        public ButtonCompare ButtonCompare = ButtonCompare.Down;
        public CtrlSegCompare SegmentCompare = CtrlSegCompare.Inside;
        public MultiCompare MultiCompare = MultiCompare.Any;
        public InputValidator[] Validators;

        public InputValidator() { }

        private void EnsureStuff()
        {
            FloatValue ??= new FloatSourceContainer(new FloatSource());
            Validators ??= new InputValidator[0];
            for (int i = 0; i < Validators.Length; i++)
            {
                Validators[i] ??= new InputValidator();
                Validators[i].EnsureStuff();
            }
        }

        public static InputValidator ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var inputValidator = new InputValidator();
            inputValidator.InputType = (InputType)reader.GetNextInt();
            inputValidator.RawX = reader.GetNextInt() > 0;
            inputValidator.Segment = (CtrlSeg)reader.GetNextInt();
            inputValidator.FloatCompare = (FloatCompare)reader.GetNextInt();
            inputValidator.ButtonCompare = (ButtonCompare)reader.GetNextInt();
            inputValidator.SegmentCompare = (CtrlSegCompare)reader.GetNextInt();
            inputValidator.MultiCompare = (MultiCompare)reader.GetNextInt();
            inputValidator.FloatValue = FloatSourceContainer.ReadSerial(reader);
            var nextInt = reader.GetNextInt();
            if (nextInt == -1)
            {
                inputValidator.Validators = null;
            }
            else
            {
                inputValidator.Validators = new InputValidator[nextInt];
                for (int i = 0; i < nextInt; i++)
                {
                    inputValidator.Validators[i] = ReadSerial(reader);
                }
            }
            return inputValidator;
        }

        public void WriteSerial(Writer writer)
        {
            EnsureStuff();
            writer.AddInt(0);
            writer.AddInt((int)InputType);
            writer.AddInt(RawX ? 7 : 0);
            writer.AddInt((int)Segment);
            writer.AddInt((int)FloatCompare);
            writer.AddInt((int)ButtonCompare);
            writer.AddInt((int)SegmentCompare);
            writer.AddInt((int)MultiCompare);
            FloatValue.WriteSerial(writer);
            if (Validators == null || InputType != 0)
            {
                writer.AddInt(-1);
                return;
            }
            writer.AddInt(Validators.Length);
            for (int i = 0; i < Validators.Length; i++)
            {
                Validators[i].WriteSerial(writer);
            }
        }
    }
}
