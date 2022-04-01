using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public GameObject Inner;
    private Vector2 _position;

    public Vector2 pos => _position;

    public void Init(Vector2 position)
    {
        this._position = position;
    }
    // private void OnMouseDown()
    // {
    //     Debug.Log("CIRCLE1!");
    //     if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
    //         Inner.GetComponent<SpriteRenderer>().color = Color.yellow;
    //     else
    //         Inner.GetComponent<SpriteRenderer>().color = Color.green;
    //     //BoardManager.Instance.SetPoint(this);
    // }
}
