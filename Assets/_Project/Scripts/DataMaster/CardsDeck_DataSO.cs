using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("Card Deck Data"), menuName = ("Data/Card Deck Data"))]
public class CardsDeck_DataSO : SingletonScriptableObject<CardsDeck_DataSO>
{
    public List<Card> cardsList = new List<Card>();
}
