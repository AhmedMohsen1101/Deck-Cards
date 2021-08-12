using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Model
    {
        //Database
        private CardsDeck_DataSO cardsData;
        
        //view Data
        private Card currentCard;
        private int playerScore;
        private bool isMyTurn;
        public Model()
        {
            this.cardsData = AppMasterManager.Instance.cardsData;
            playerScore = 0;
        }

        public Card GetRandomCard()
        {
            if (cardsData.cardsList.Count > 0)
            {
                int randomCard = Random.Range(0, cardsData.cardsList.Count);
                currentCard = cardsData.cardsList[randomCard];
                //cardsData.cardsList.Remove(card);
                return currentCard;
            }
            return null;
        }
        public int GetCardValue()
        {
            return currentCard.value;
        }
        public void UpdateScore(int value)
        {
            playerScore += value;
        }
        public int GetScore()
        {
            return playerScore;
        } 
        public void SetTurnState(bool b)
        {
            isMyTurn = b;
        }
    }

}
