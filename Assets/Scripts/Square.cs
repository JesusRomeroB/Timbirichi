using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private float points = 0;
    private bool scored = false;
    public LayerMask lineaLayer;
    private GameObject Score;
    List<Collider2D> collidedObjects = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        Score = this.transform.Find("Square").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // var numberOfColliders = collidedObjects.Count; // this should give you the number you need
        // Debug.Log(numberOfColliders);
        //Debug.Log(points);
    }
    private void FixedUpdate()
    {
        Collider2D pointCheckRight = Physics2D.OverlapCircle(new Vector2(transform.position.x + 0.315f, transform.position.y + 0.15f), 0.03f, lineaLayer);
        Collider2D pointCheckLeft = Physics2D.OverlapCircle(new Vector2(transform.position.x - 0.515f, transform.position.y + 0.15f), 0.03f, lineaLayer);
        Collider2D pointCheckUp = Physics2D.OverlapCircle(new Vector2(transform.position.x - 0.115f, transform.position.y + 0.550f), 0.03f, lineaLayer);
        Collider2D pointCheckDown = Physics2D.OverlapCircle(new Vector2(transform.position.x - 0.115f, transform.position.y - 0.255f), 0.03f, lineaLayer);

        // Si todos los puntos estan colisionando y no es el inicio del juego es punto para este cuadro
        if (scored == false && pointCheckRight != null && pointCheckLeft != null && pointCheckUp != null && pointCheckDown != null && (GameManager.Instance.GetGameState != GameManager.GameState.start))
        {
            Debug.Log(pointCheckUp);
            BoardManager.Instance.ChangeTurn();
            if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
            {
                Score.GetComponent<SpriteRenderer>().color = Color.yellow;
            }

            else
            {
                Score.GetComponent<SpriteRenderer>().color = Color.green;
            }
            GameManager.Instance.Score(GameManager.Instance.GetGameState);
            scored = true;
        }
    }
    // Debug OverlapCircle
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x + 0.315f, transform.position.y + 0.15f), 0.03f); // Derecha
        Gizmos.DrawWireSphere(new Vector2(transform.position.x - 0.515f, transform.position.y + 0.15f), 0.03f); // Izquierda
        Gizmos.DrawWireSphere(new Vector2(transform.position.x - 0.115f, transform.position.y + 0.550f), 0.03f); // Arriba
        Gizmos.DrawWireSphere(new Vector2(transform.position.x - 0.115f, transform.position.y - 0.255f), 0.03f); // Abajo
    }
}
