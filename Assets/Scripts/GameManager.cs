using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState _gameState;
    private GameState winningPlayerState;
    private string winningPlayerString;
    private float player1Score;

    private float player2Score;
    private int winningScore;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        _gameState = GameState.start;
        int maxPoints = (BoardManager.Instance.GetWidth - 1) * (BoardManager.Instance.GetHeight - 1);
        Debug.Log("maxPoints: " + maxPoints);
        winningScore = (int)Math.Ceiling((double)maxPoints / (double)2);
        if (winningScore % 2 == 0)
        {
            winningScore++;
        }
        Debug.Log("winningScore: " + winningScore);
    }

    public void UpdateGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public GameState GetGameState => _gameState;

    public void Score(GameState player)
    {
        if (player == GameState.player1)
        {
            player1Score++;
            Debug.Log(player1Score);
            if (player1Score == winningScore)
            {
                GameFinished(player);
            }
        }
        else if (player == GameState.player2)
        {
            player2Score++;
            Debug.Log(player2Score);
            if (player2Score == winningScore)
            {
                GameFinished(player);
            }
        }
    }
    public void SwitchPlayer()
    {
        if (_gameState == GameState.player1)
        {
            _gameState = GameState.player2;
        }
        else
        {
            _gameState = GameState.player1;
        }
    }

    public void GameFinished(GameState player)
    {
        Debug.Log("Player: " + player + " won!");
        if (player == GameState.player1)
        {
            winningPlayerState = GameState.player1;
            winningPlayerString = "Player 1";
        }
        else
        {
            winningPlayerState = GameState.player2;
            winningPlayerString = "Player 2";
        }
        UpdateGameState(GameState.end);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_gameState)
        {
            case GameState.start:
                UpdateGameState(GameState.player1);
                MenuManager.Instance.SetScorePlayer1Label(player1Score);
                MenuManager.Instance.SetScorePlayer2Label(player2Score);
                break;
            case GameState.player1:
                MenuManager.Instance.SetScorePlayer1Label(player1Score);
                MenuManager.Instance.SetScorePlayer2Label(player2Score);
                break;
            case GameState.player2:
                MenuManager.Instance.SetScorePlayer1Label(player1Score);
                MenuManager.Instance.SetScorePlayer2Label(player2Score);
                break;
            case GameState.end:
                PlayerPrefs.SetString("WinningPlayer", winningPlayerString);
                SceneManager.LoadScene("EndScene");
                break;
        }
    }
    public enum GameState
    {
        start,
        player1,
        player2,
        end
    }
}
