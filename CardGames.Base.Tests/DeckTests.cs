namespace CardGames.Base.Tests;

public class DeckTests
{
    [Fact]
    public void TestStandardDeck()
    {
      int aceHighValue = 15;
      IEnumerable<ACard> standardDeck = Deck.BuildStandardDeck(aceHighValue).Cards;

      // In a traditional deck there should be exactly 4 Suits
      Assert.Equal(4, standardDeck.Select(x=>x.Suit).Distinct().Count());
      // There should also be 13 Cards per suit
      foreach(Suit suit in standardDeck.Select(x=>x.Suit).Distinct()){
        var suitCards = standardDeck.Where(x=>x.Suit.Equals(suit)).OrderBy(x=>x.Value).ToList();
        Assert.Equal(13, suitCards.Count());
        // For each suit there should be numeric cards 2-10 and face cards Jack, Queen, King & Ace
        for(int i = 2; i < 11; i++){
          Assert.NotEmpty(suitCards.Where(x=>x.Name == $"{i}"));
        }
        Assert.NotEmpty(suitCards.Where(x=>x.Name == "Jack"));
        Assert.NotEmpty(suitCards.Where(x=>x.Name == "Queen"));
        Assert.NotEmpty(suitCards.Where(x=>x.Name == "King"));
        Assert.NotEmpty(suitCards.Where(x=>x.Name == "Ace"));
      }
    }

    [Fact]
    public void TestDeckEquals()
    {
      // Test Same Order is Equals
      var deck1 = Deck.BuildStandardDeck();
      var deck2 = Deck.BuildStandardDeck();
      Assert.True(deck1.Equals(deck2));
    }

    [Fact]
    public void TestDeckNotEqualOnDifferentOrder()
    {
      // Different Order is not Equals
      var deck1 = Deck.BuildStandardDeck();
      var deck2 = Deck.BuildStandardDeck();
      deck2.Shuffle();
      Assert.False(deck1.Equals(deck2));
    }

    [Fact]
    public void DeckNotEqualOnDifferentSizes()
    {
      // Different Count Not Equals
      var deck1 = new Deck(new List<ACard>(){
          new StandardCard(Suit.Hearts, 1, "One")
          });
      var deck2 = Deck.BuildStandardDeck();

      Assert.False(deck1.Equals(deck2));
    }

    [Fact]
    public void DeckNotEqualOnDifferentCards()
    {
      // Different Cards not Equals
      var deck1 = new Deck(new List<ACard>(){
          new StandardCard(Suit.Hearts, 1, "One")
          });

      var deck2 = new Deck(new List<ACard>(){
          new StandardCard(Suit.Spades, 1, "One")
          });
      Assert.False(deck1.Equals(deck2));
    }
}
