public class Deck
{
    public Deck(List<ICard> cards)
    {
        Cards = cards;
    }

    public List<ICard> Cards { get; }

    // Method to Shuffle the Deck
    public void Shuffle()
    {

    }

    // Method to Deal n number of cards to i Hands
    public List<Hand> Deal(int numberOfCardsPerHand, int numberOfHandsToBeDealt)
    {
        return new();
    }

    public static Deck BuildStandardDeck(int aceHighValue = 15)
    {
        List<ICard> StandardDeckCards = new(); 
        foreach(Suit suit in Enum.GetValues<Suit>().Cast<Suit>()){
            for(int i = 1; i < 14; i++){
                if (i.Equals(1))
                {
                    StandardDeckCards.Add(new Ace(suit, i, aceHighValue));
                }
                else
                {
                  string? name =null;
                  switch(i){
                    case 11: name = "Jack"; break;
                    case 12: name = "Queen"; break;
                    case 13: name = "King"; break;
                    default: name = i.ToString(); break;
                  } 
                    StandardDeckCards.Add(new StandardCard(suit, i, name));
                }
            }   
        }
        return new Deck(StandardDeckCards);
    }
}
