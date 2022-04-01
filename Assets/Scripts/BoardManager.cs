using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public int Width = 6;
    public int Height = 6;
    public Point PointPrefab;
    public Line LinePrefab;

    public Square SquarePrefab;

    public int GetWidth => Width;
    public int GetHeight => Height;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                var pos = new Vector2(i, j);
                Instantiate(PointPrefab, pos, Quaternion.identity);
                if (j != 0)
                {
                    var pos2 = new Vector2(i, j - 0.5f);
                    var xd = Instantiate(LinePrefab, pos2, Quaternion.identity);
                }
                if (i != (Height - 1))
                {
                    var pos3 = new Vector2(i + 0.5f, j);
                    var l = Instantiate(LinePrefab, pos3, Quaternion.identity);
                    l.transform.Rotate(0f, 0f, 90f);
                }
                if (i != (Height - 1) && j != 0)
                {
                    var pos4 = new Vector2(i + 0.6f, j - 0.65f);
                    Instantiate(SquarePrefab, pos4, Quaternion.identity);
                }

            }
        }
        var center = new Vector2((float)Height / 2 - 0.5f, (float)Width / 2 - 0.5f);
        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
    }

    public void ChangeTurn()
    {
        GameManager.Instance.SwitchPlayer();
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
