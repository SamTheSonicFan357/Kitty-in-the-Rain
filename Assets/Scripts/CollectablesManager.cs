using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class CollectablesManager : MonoBehaviour
{
    public Tilemap tileMap;
    public GridBrush brush;
    public GameObject collectable;
    public Transform generationPoint;
    //public Transform deletionPoint;
    public float distanceBetween;

    private const int platformWidth = 1;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 translation = new Vector3(distanceBetween + platformWidth, 0f);
        transform.position += translation;

        Vector3Int currentCell = tileMap.WorldToCell(transform.position + new Vector3(0f, 0.5f));
        brush.Paint(tileMap, collectable, currentCell);
    }
}
