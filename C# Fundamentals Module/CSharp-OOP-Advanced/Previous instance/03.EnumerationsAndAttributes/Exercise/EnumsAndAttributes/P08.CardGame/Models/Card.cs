using System;

public class Card : IComparable<Card>
{
    public Card(string rank, string suit)
    {
        this.Suit = this.ParseSuit(suit);
        this.Rank = this.ParseRank(rank);
    }

    public int Power => (int)this.Suit + (int)this.Rank;

    public CardSuit Suit { get; private set; }

    public CardRank Rank { get; private set; }

    private CardRank ParseRank(string rank)
    {
        CardRank cardRank;
        if (Enum.TryParse<CardRank>(rank, out cardRank))
        {
            return cardRank;
        }

        throw new ArgumentException("No such card exists.");
    }

    private CardSuit ParseSuit(string suit)
    {
        CardSuit cardSuit;
        if (Enum.TryParse<CardSuit>(suit, out cardSuit))
        {
            return cardSuit;
        }

        throw new ArgumentException("No such card exists.");
    }

    public override string ToString()
    {
        return $"{this.Rank} of {this.Suit}";
    }

    public int CompareTo(Card other)
    {
        return this.Power.CompareTo(other.Power);
    }
}
