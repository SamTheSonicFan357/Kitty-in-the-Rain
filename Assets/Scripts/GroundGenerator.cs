using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundGenerator : MonoBehaviour
{
    public Tilemap tileMap;
    public Tile groundTile;
    public Transform generationPoint;
    public float distanceBetween;

    private const int groundWidth = 1;

    private void Start()
    {
        int screenHeight = (int)(2 * Camera.main.orthographicSize);
        int screenWidth = (int)(screenHeight * Camera.main.aspect + 1);

        for (int i = 0; i < screenWidth; i++)
        {
            Vector3Int currentCell = tileMap.WorldToCell(transform.position);

            if (transform.position.x < generationPoint.position.x)
            {
                Vector3 translation = new Vector3(distanceBetween + groundWidth, 0f);
                transform.position += translation;
                generationPoint.position += translation;
                tileMap.SetTile(currentCell, groundTile);
            }
        }
    }

    private void Update()
    {
        Vector3Int currentCell = tileMap.WorldToCell(transform.position);

        if (transform.position.x < generationPoint.position.x)
        {
            Vector3 translation = new Vector3(distanceBetween + groundWidth, 0f);
            transform.position += translation;
            tileMap.SetTile(currentCell, groundTile);
        }
    }
}
