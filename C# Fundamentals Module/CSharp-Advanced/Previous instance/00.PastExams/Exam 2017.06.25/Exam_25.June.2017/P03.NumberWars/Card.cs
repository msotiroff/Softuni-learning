namespace P03.NumberWars
{
    internal class Card
    {
        public Card()
        {
        }

        public Card(long value, int letterValue)
        {
            this.CardValue = value;
            this.LetterValue = letterValue;
        }

        public long CardValue { get; set; }

        public int LetterValue { get; set; }
    }
}
