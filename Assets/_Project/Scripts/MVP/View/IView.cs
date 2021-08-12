
namespace View
{
    public interface IView
    {
        void DisplayCard(Card card);
        void DisplayScore(int score);
        void UpdateTurn(bool isMyTurn);
        int GetCardValue();
        int GetScoreValue();
    }

}
