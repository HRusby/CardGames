// See https://aka.ms/new-console-template for more information

// Output each card in both lists in order if the same highlight Green
void PrintComparison(IEnumerable<ACard> A, IEnumerable<ACard> B){
  if(A.Count() != B.Count()){
    throw new Exception("Comparison Arguments are not of the same length");
  }
  int maxDisplayLength = 20;
  for(int i = 0; i < A.Count(); i++){
    ACard cardA = A.ElementAt(i);
    ACard cardB = B.ElementAt(i);
    Console.WriteLine($"{cardA.ToString().PadLeft(maxDisplayLength)}|{cardB.ToString().PadRight(maxDisplayLength)}");
    Console.ResetColor();
  }
}

Deck deckOne = Deck.BuildStandardDeck(15);
deckOne.Shuffle();
Deck deckTwo = Deck.BuildStandardDeck(15);
deckTwo.Shuffle();

// Output the Deck as a comparison if two decks are not equal
if(!deckOne.Equals(deckTwo))
  PrintComparison(deckOne.Cards, deckTwo.Cards);

// Reorder Deck to Demonstrate CompareTo
deckOne.Cards.Sort();
deckTwo.Cards.Sort();
if(!deckOne.Equals(deckTwo))
  PrintComparison(deckOne.Cards, deckTwo.Cards);
