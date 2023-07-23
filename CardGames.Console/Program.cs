// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Deck standardDeck = Deck.BuildStandardDeck(15);
foreach(ACard card in standardDeck.Cards){
    Console.WriteLine(card.ToString());
}
Console.WriteLine("Done");
