using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicUI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text roundText;

    private GameLogic gameLogic;
    private void OnEnable()
    {
        if (gameLogic == null)
            gameLogic = GetComponent<GameLogic>();

        gameLogic.OnRoundChange += UpdateRoundText;
        gameLogic.OnGameEnd += GameEnd;

        UpdateRoundText(0);
    }
    private void OnDisable()
    {
        gameLogic.OnRoundChange -= UpdateRoundText;
        gameLogic.OnGameEnd -= GameEnd;
    }

    private void UpdateRoundText(int round)
    {
        if (!ReferenceEquals(roundText, null))
            roundText.text = "Round " + round;
    }

    private void GameEnd(string value)
    {
        if (!ReferenceEquals(roundText, null))
            roundText.text = value;
    }
}
