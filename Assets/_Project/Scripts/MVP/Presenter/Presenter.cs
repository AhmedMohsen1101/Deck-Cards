using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presenter
{
    public class Presenter : IPresenter
    {
        View.IView view;
        Model.Model deckModel;

        public Presenter(View.IView view)
        {
            deckModel = new Model.Model();

            this.view = view;
        }


        public void DrawCard()
        {
            Card card = deckModel.GetRandomCard();
            view.DisplayCard(card);
        }

        public void StartTurn()
        {
            deckModel.SetTurnState(true);
            view.UpdateTurn(true);
        }

        public void EndTurn()
        {
            deckModel.SetTurnState(false);
            view.UpdateTurn(false);
        }

        public void UpdateScore(int score)
        {
            deckModel.UpdateScore(score);
            view.DisplayScore(deckModel.GetScore());
        }

        public int GetCardValue()
        {
            return deckModel.GetCardValue();
        }

        public int GetScoreValue()
        {
            return deckModel.GetScore();
        }
    }

}
