namespace CardGame.Interfaces
{
    interface ICardGame
    {
        void StartGame();

        void InitializeDeckOfCards();

        void PrintDeck();

        void ShuffleDeck();

        void PlayCard();
    }
}
