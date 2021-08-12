using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Model
    {
        //Database
        private CardsDeck_DataSO cardsDataSO;
        
        //view Data
        private Card currentCard;
        private int playerScore;
        private bool isMyTurn;
        public Model()
        {
            this.cardsDataSO = AppMasterManager.Instance.cardsData;
            playerScore = 0;
        }

        public Card GetRandomCard()
        {
            if (cardsDataSO.cardsDeck.list.Count > 0)
            {
                int randomCard = Random.Range(0, cardsDataSO.cardsDeck.list.Count);
                currentCard = cardsDataSO.cardsDeck.list[randomCard];
                cardsDataSO.cardsDeck.list.Remove(currentCard);
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
