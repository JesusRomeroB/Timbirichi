using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManagerEndScene : MonoBehaviour
{
    public TextMeshProUGUI WinningPlayer;
    // Start is called before the first frame update
    void Start()
    {
        string winninPlayer = PlayerPrefs.GetString("WinningPlayer");
        WinningPlayer.text = winninPlayer + " won! ";
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
