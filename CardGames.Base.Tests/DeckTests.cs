namespace CardGames.Base.Tests;

public class DeckTests
{
    [Fact]
    public void TestStandardDeck()
    {
       IEnumerable<ACard> standardDeck = Deck.BuildStandardDeck().Cards;

      // In a traditional deck there should be exactly 4 Suits
      Assert.Equal(4, standardDeck.Select(x=>x.Suit).Distinct().Count());
      // There should also be 13 Cards per suit
      foreach(Suit suit in standardDeck.Select(x=>x.Suit).Distinct()){
        var selectResults = standardDeck.Where(x=>x.Suit.Equals(suit)).ToList();
        Assert.Equal(13, standardDeck.Where(x=>x.Suit.Equals(suit)).Count());
      }
    }
}
