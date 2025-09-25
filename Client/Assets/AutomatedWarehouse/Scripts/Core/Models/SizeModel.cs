namespace AutomatedWarehouse.Core.Models
{
    public struct SizeModel
    {
        public int Width;
        public int Length;

        public SizeModel(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public override readonly string ToString()
        {
            return $"{Width}x{Length}";
        }
    }
}