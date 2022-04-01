using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public TextMeshProUGUI ScorePlayer1Label;
    public TextMeshProUGUI ScorePlayer2Label;
    private void Awake()
    {
        Instance = this;
    }

    public void SetScorePlayer1Label(float scoreCount)
    {
        ScorePlayer1Label.text = "Player 1: " + scoreCount;
    }
    public void SetScorePlayer2Label(float scoreCount)
    {
        ScorePlayer2Label.text = "Player 2: " + scoreCount;
    }
}
