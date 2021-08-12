using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;
    public int value;

    public Card (string cardName, int value)
    {
        this.cardName = cardName;
        this.value = value;
    }
}
