namespace BlazorPractice.Components.Pages
{
    public record Point
    {
        public int X;
        public int Y;

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}