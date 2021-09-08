namespace CardTrick
{
    public static class EnumExtensions
    {
        public static string ToShortString(this Face value) => (int) value < 11 ? ((int) value).ToString() : value.ToString()[0].ToString();
        public static string ToShortString(this Suit value) => value.ToString()[0].ToString();
    }
}