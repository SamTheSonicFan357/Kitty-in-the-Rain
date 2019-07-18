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

    // Update is called once per frame
    private void Update()
    {
        Vector3Int currentCell = tileMap.WorldToCell(transform.position);

        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + distanceBetween + groundWidth, transform.position.y);
            tileMap.SetTile(currentCell, groundTile);
            //Instantiate(groundTile, transform);
        }
    }
}
