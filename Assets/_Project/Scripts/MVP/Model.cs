using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Model
    {
        private List<Card> cardsDeck;

        public Model()
        {
            var cardsDeck = JsonUtility.FromJson<CardsDeck>("");
            this.cardsDeck = new List<Card>();
            this.cardsDeck = cardsDeck.cardsDeckList;
        }
        public Card GetRandomCard()
        {
            if (cardsDeck.Count > 0)
            {
                int randomCard = Random.Range(0, cardsDeck.Count);
                Card card = cardsDeck[randomCard];

                cardsDeck.Remove(card);

                return card;
            }
            return null;
        }
    }

}
