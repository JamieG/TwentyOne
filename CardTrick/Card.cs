namespace CardTrick
{
    public record Card(Suit Suit, Face Face)
    {
        public override string ToString() => $"{Face.ToShortString().PadLeft(2)}{Suit.ToShortString()}";
    }
}