public class Hand
{
    public Hand(IEnumerable<ICard> cards)
    {
        Cards = cards;
    }

    public IEnumerable<ICard> Cards { get; }
}
