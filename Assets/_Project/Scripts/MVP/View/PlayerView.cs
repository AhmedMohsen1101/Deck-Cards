using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PlayerView : MonoBehaviour, IView
    {
        public CardWorldPositions cardWorldPositions;
        public ViewUI viewUI;
        public Visuals visuals;

        private Presenter.IPresenter presenter;
        [HideInInspector] public GameObject cardGameObject;

        void Start()
        {
            presenter = new Presenter.Presenter(this);
        }

        public void DisplayCard(Card card)
        { 
            CreateCard(card);
        }
        public void UpdateTurn(bool isMyTurn)
        {
            if (!ReferenceEquals(viewUI.drawCardButton, null))
                viewUI.drawCardButton.interactable = isMyTurn;
        }

        public void DisplayScore(int score)
        {
            if (!ReferenceEquals(viewUI.playerScoreText.text, null))
            {
                LeanTween.scale(viewUI.playerScoreText.gameObject, Vector3.one * 3f, 0.5f).setEasePunch();
                viewUI.playerScoreText.text = score.ToString();

            }
        }

        private GameObject CreateCard(Card card)
        {
            cardGameObject = Instantiate(Resources.Load(card.cardName)) as GameObject;
            cardGameObject.transform.position = cardWorldPositions.cardWorldTransform.position;
            cardGameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            return cardGameObject;
        }
       
        #region Events
        /// <summary>
        /// fired by the player UI button 
        /// </summary>
        public void UserEventGetCard()
        {
            presenter.DrawCard();
        }
        /// <summary>
        /// starting turn input from Game Logic based on player state
        /// </summary>
        public void StartTurnInput()
        {
            presenter.StartTurn();
        }
        /// <summary>
        /// finishing turn input from Game Logic based on player state
        /// </summary>
        public void EndTurnInput()
        {
            presenter.EndTurn();
        }
        public int GetCardValue()
        {
            return presenter.GetCardValue();
        }
        public void InputUpdateScore(int score)
        {
            presenter.UpdateScore(score);
        }

        public int GetScoreValue()
        {
            return presenter.GetScoreValue();
        }
        public void PlayWinEffect()
        {
            if (!ReferenceEquals(visuals.winEffect, null))
                visuals.winEffect.Play();
        }
        public void PlayDrawEffect()
        {
            if (!ReferenceEquals(visuals.DrawEffect, null))
                visuals.DrawEffect.Play();
        }
        #endregion
    }

    [System.Serializable]
    public class CardWorldPositions
    {
        [Tooltip("Ref to the position of card in the scene")]
        public Transform cardWorldTransform;
        [Tooltip("Ref to tweening position when the round ended")]
        public Transform cardTweenTransform;
    }

    [System.Serializable]
    public class ViewUI
    {
        public TMPro.TMP_Text playerScoreText;
        public Button drawCardButton;
    }

    [System.Serializable]
    public class Visuals
    {
        public ParticleSystem winEffect;
        public ParticleSystem DrawEffect;
    }
}
