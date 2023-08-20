public class ACard : ICard, IComparable
{
    public Suit Suit { get; private set; }
    public virtual int Value { get; protected set;}
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

    public string ToStringVisual(){
      var width = 10;
      var widthBody = 8;
      var borderLine = new String('-', width);
      var populatedBodyWidth = 8 - 1 - Value.ToString().Length;
      return $@"
        {borderLine}
        -{Suit.ToString()[0]}{new String(' ', populatedBodyWidth)}{Value}-
        -{new String(' ', widthBody)}-
        -{new String(' ', widthBody)}-
        -{Value}{new String(' ', populatedBodyWidth)}{Suit.ToString()[0]}-
        {borderLine}
        ";
    }

    public override bool Equals(object? obj)
    {
      ACard? otherCard = obj as ACard;
      if(otherCard == null) return false;
      return Suit.Equals(otherCard.Suit) && Value.Equals(otherCard.Value);
    }

    public override int GetHashCode()
    {
      return Suit.GetHashCode() + Value.GetHashCode() + base.GetHashCode();
    }

    public int CompareTo(object? obj){
      if (obj == null) return 1;

      ACard? otherCard = obj as ACard;
      if (otherCard != null){
        var suitComparison = Suit.CompareTo(otherCard.Suit);
        var valueComparison = Value.CompareTo(otherCard.Value);
        // Compare by Suit then by Value
        return suitComparison == 0 ? valueComparison : suitComparison;
      }
      throw new ArgumentException("Object is not an ACard");
    }
}

