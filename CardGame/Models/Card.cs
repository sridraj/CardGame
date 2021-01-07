namespace CardGame.Models
{
    public class Card
    {
        public string value;
        public static string[] SuitsArray = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };
        public string suit;

        public Card(string _value, string _suit)
        {
            value = _value;
            suit = _suit;
        }
    }
}
