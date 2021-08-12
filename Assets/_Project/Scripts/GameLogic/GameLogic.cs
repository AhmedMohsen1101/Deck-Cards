using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private List<View.PlayerView> players = new List<View.PlayerView>();

    private View.PlayerView currentPlayer;

    private int turn = 0;
    private int round = 0;
    private int playerIndex = 0;
    private bool gameCompleted;
    #region Delegation
    public UnityAction<int> OnRoundChange;
    public UnityAction<string> OnGameEnd;
    #endregion
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);

        if (players.Count == 0)
            yield break;

        StartWithRandomPlayer();
    }
    /// <summary>
    /// 
    /// </summary>
    private void StartWithRandomPlayer()
    {
        playerIndex = Random.Range(0, players.Count);
        currentPlayer = players[playerIndex];
        currentPlayer.StartTurnInput();
    }
    
    /// <summary>
    /// Event by players
    /// </summary>
    public void EndTurn()
    {
        if (gameCompleted)
        {
            foreach (var player in players)
            {
                player.EndTurnInput();
            }
            return;
        }

        turn++;
        if (turn % 2 == 0)
        {
            StartCoroutine(WinContition());

            UpdateRound();
        }

        StartCoroutine(RoutineEndingTurn());
    }

    /// <summary>
    /// number of rounds for two player is 26
    /// </summary>
    private void UpdateRound()
    {
        round++;
        OnRoundChange?.Invoke(round);

        if (round == (52 / 2))
        {
            if (players[0].GetScoreValue() == players[1].GetScoreValue())
            {
                GameNoWinner();
            }
            else
            {
                GameWinner();
            }

            gameCompleted = true;
        }
    }


    /// <summary>
    /// Rountine win or lose Condition
    /// Tweening UI and Game Objects
    /// </summary>
    /// <returns></returns>
    private IEnumerator WinContition()
    {
        yield return new WaitForSeconds(1);

        if (players[0].GetCardValue() == players[1].GetCardValue())
        {
            TurnNoWinner();
        }
        else
        {
            TurnWinner();
        }
    }
    /// <summary>
    /// Routine before the next turn or round begin
    /// </summary>
    /// <returns></returns>
    private IEnumerator RoutineEndingTurn()
    {
        currentPlayer.EndTurnInput();
        yield return new WaitForSeconds(1);
        
        playerIndex++;

        if (playerIndex >= players.Count)
            playerIndex = 0;

        currentPlayer = players[playerIndex];
        currentPlayer.StartTurnInput();
    }

    /// <summary>
    /// When Final score is equal
    /// </summary>
    private void GameNoWinner()
    {
        OnGameEnd?.Invoke("Draw!!");
    }
    /// <summary>
    /// When one player wins
    /// </summary>
    private void GameWinner()
    {
        int playerOneScore = players[0].GetScoreValue();
        int playerTwoScore = players[1].GetScoreValue();

        if (playerOneScore > playerTwoScore)
        {
            OnGameEnd?.Invoke("Player One Wins");
        }
        else
        {
            OnGameEnd?.Invoke("Player Two Wins");
        }
    }
    /// <summary>
    /// When the player cards value are equal
    /// </summary>
    private void TurnNoWinner()
    {
        foreach (var player in players)
        {
            player.InputUpdateScore(-player.GetCardValue());
            TweenCard(player, player.cardWorldPositions.cardTweenTransform.position);
            player.PlayDrawEffect();
        }
    }
    /// <summary>
    /// When the player cards value are bigger
    /// </summary>
    private void TurnWinner()
    {
        int playerOneScore = players[0].GetCardValue();
        int playerTwoScore = players[1].GetCardValue();
       
        if (playerOneScore > playerTwoScore)
        {
            players[0].InputUpdateScore(playerOneScore + playerTwoScore);
            TweenCard(players[0], players[0].cardWorldPositions.cardTweenTransform.position);
            TweenCard(players[1], players[0].cardWorldPositions.cardTweenTransform.position);

            players[0].PlayWinEffect();
        }
        else if (playerOneScore < playerTwoScore)
        {
            players[1].InputUpdateScore(playerOneScore + playerTwoScore);
            TweenCard(players[1], players[1].cardWorldPositions.cardTweenTransform.position);
            TweenCard(players[0], players[1].cardWorldPositions.cardTweenTransform.position);

            players[1].PlayWinEffect();
        }
    }

    /// <summary>
    /// Tween the card gameobject to make a cool effect
    /// </summary>
    /// <param name="playerView"></param>
    /// <param name="pos"></param>
    private void TweenCard(View.PlayerView playerView, Vector3 pos)
    {
        LeanTween.moveLocal(playerView.cardGameObject, pos, 0.5f);

        Destroy(playerView.cardGameObject, 0.5f);
    }
}
