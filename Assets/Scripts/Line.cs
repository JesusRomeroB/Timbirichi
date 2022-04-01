using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private GameObject Square;
    private GameObject TopCircle;
    private GameObject BotCircle;
    private Vector2 _position;
    private bool touched = false;
    public Vector2 pos => _position;
    void Start()
    {
        Square = this.transform.Find("Square").gameObject;
        TopCircle = this.transform.Find("TopCircle").gameObject;
        BotCircle = this.transform.Find("BotCircle").gameObject;
    }
    public void Init(Vector2 position)
    {
        this._position = position;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (GameManager.Instance.GetGameState != GameManager.GameState.end)
        {
            if (!touched)
            {
                if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
                {
                    Square.GetComponent<SpriteRenderer>().color = Color.yellow;
                    TopCircle.GetComponent<SpriteRenderer>().color = Color.yellow;
                    BotCircle.GetComponent<SpriteRenderer>().color = Color.yellow;
                }

                else
                {
                    Square.GetComponent<SpriteRenderer>().color = Color.green;
                    TopCircle.GetComponent<SpriteRenderer>().color = Color.green;
                    BotCircle.GetComponent<SpriteRenderer>().color = Color.green;
                }
                touched = true;
                GetComponent<CapsuleCollider2D>().size = new Vector2(1.2f, 0.5f);
                BoardManager.Instance.ChangeTurn();
            }
        }
    }
}
