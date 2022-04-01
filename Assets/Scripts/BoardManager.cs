using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    private int Width = 6;
    private int Height = 6;
    public Point PointPrefab;
    public Line LinePrefab;

    public Square SquarePrefab;

    public int GetWidth => Width;
    public int GetHeight => Height;
    [SerializeField] float boundingBoxPadding = 0.5f;
    [SerializeField] float minimumOrthographicSize = 2f;
    private List<Transform> targets = new List<Transform>();
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Width = PlayerPrefs.GetInt("Size");
        Debug.Log("Width " + Width);
        Height = PlayerPrefs.GetInt("Size");
        Debug.Log("Height " + Height);
        GenerateBoard();
    }


    private void GenerateBoard()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                var pos = new Vector2(i, j);
                var point = Instantiate(PointPrefab, pos, Quaternion.identity);
                targets.Add(point.transform);
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
        Rect boundingBox = CalculateTargetsBoundingBox();
        Camera.main.orthographicSize = CalculateOrthographicSize(boundingBox);
        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
    }

    public void ChangeTurn()
    {
        GameManager.Instance.SwitchPlayer();
    }

    Rect CalculateTargetsBoundingBox()
    {
        float minX = Mathf.Infinity;
        float maxX = Mathf.NegativeInfinity;
        float minY = Mathf.Infinity;
        float maxY = Mathf.NegativeInfinity;

        foreach (Transform target in targets)
        {
            Vector3 position = target.position;

            minX = Mathf.Min(minX, position.x);
            minY = Mathf.Min(minY, position.y);
            maxX = Mathf.Max(maxX, position.x);
            maxY = Mathf.Max(maxY, position.y);
        }

        return Rect.MinMaxRect(minX - boundingBoxPadding, maxY + boundingBoxPadding, maxX + boundingBoxPadding, minY - boundingBoxPadding);
    }

    float CalculateOrthographicSize(Rect boundingBox)
    {
        float orthographicSize = Camera.main.orthographicSize;
        Vector3 topRight = new Vector3(boundingBox.x + boundingBox.width, boundingBox.y, 0f);
        Vector3 topRightAsViewport = Camera.main.WorldToViewportPoint(topRight);

        if (topRightAsViewport.x >= topRightAsViewport.y)
            orthographicSize = Mathf.Abs(boundingBox.width) / Camera.main.aspect / 2f;
        else
            orthographicSize = Mathf.Abs(boundingBox.height) / 2f;

        return Mathf.Clamp(orthographicSize, minimumOrthographicSize, Mathf.Infinity);
    }
}
