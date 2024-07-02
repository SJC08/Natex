namespace Asjc.Natex.Tests
{
    public record Record
    {
        public Record() { }

        public Record(string? text) => Text = text;

        public Record(int? number) => Number = number;

        public Record(string? text, int? number)
        {
            Text = text;
            Number = number;
        }

        public string? Text { get; }

        public int? Number { get; }
    }
}
