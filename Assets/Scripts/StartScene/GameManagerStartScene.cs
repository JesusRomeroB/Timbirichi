using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerStartScene : MonoBehaviour
{
    public Slider _slider;
    public TextMeshProUGUI sizeText;
    private int size = 2;
    // Start is called before the first frame update
    void Start()
    {
        _slider.onValueChanged.AddListener((v)=> 
        {   
            size = (int) v;
            sizeText.text = size+"x"+size;
        });
    }

    // Update is called once per frame
    public void OnRestartClick()
    {
        PlayerPrefs.SetInt("Size", (int) size + 1);
        SceneManager.LoadScene("SampleScene");
    }
}
