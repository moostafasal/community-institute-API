namespace community_institute_API.Data.Domin
{
    public class Capture
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }

        public Capture() { }

        public Capture(string text, int index, int length)
        {
            Text = text;
            Index = index;
            Length = length;
        }
    }

}
