public class ACard : ICard
{
    public Suit Suit { get; }
    public int Value { get; }
    public string? Name { get; }

    public ACard(Suit suit, int value, string? name)
    {
      Suit = suit;
      Value = value;
      Name = string.IsNullOrEmpty(name) ? value.ToString() : name;
    }

    public override string ToString(){
      return $"{Name} of {Suit}";
    }
}

