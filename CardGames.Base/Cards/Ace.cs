public class Ace : ACard, ICard
{
    private readonly int lowValue;
    private readonly int highValue;

    public Ace(Suit suit,
             int lowValue,
             int highValue) : base(suit, lowValue, "Ace")
    {
        this.lowValue = lowValue;
        this.highValue = highValue;
    }
}
