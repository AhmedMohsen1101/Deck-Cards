
namespace Presenter
{
    public interface IPresenter
    {
        int GetCardValue();
        int GetScoreValue();
        
        void DrawCard();

        void StartTurn();

        void EndTurn();

        void UpdateScore(int score);
    }
}