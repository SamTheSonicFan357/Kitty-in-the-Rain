﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundManager : MonoBehaviour
{
    public GameObject house;
    public Tilemap tileMap;
    public Tile groundTile;
    public GameObject generationPoint;
    public Transform deletionPoint;
    public float distanceBetween;
    public float minStartGapTime = 1;
    public float maxStartGapTime = 3;
    public int minGaps = 5;
    public int maxGaps = 8;

    private int tilesTilEnd;
    private float elapsedGapWaitTime;
    private float gapWaitTime;
    private int gaps = 0;
    private const int groundWidth = 1;

    private void Start()
    {
        int screenHeight = (int)(2 * Camera.main.orthographicSize);
        int screenWidth = (int)(screenHeight * Camera.main.aspect + 1);

        for (int i = 0; i < screenWidth; i++)
        {
            Vector3Int currentCell = tileMap.WorldToCell(transform.position);

            if (transform.position.x < generationPoint.transform.position.x)
            {
                Vector3 translation = new Vector3(distanceBetween + groundWidth, 0f);
                transform.position += translation;
                generationPoint.transform.position += translation;
                tileMap.SetTile(currentCell, groundTile);
            }
        }

        tilesTilEnd = Random.Range(80, 150);
        gapWaitTime = Random.Range(minStartGapTime, maxStartGapTime);
    }

    private void Update()
    {
        if (elapsedGapWaitTime > gapWaitTime)
        {
            gapWaitTime = Random.Range(minStartGapTime, maxStartGapTime);
            elapsedGapWaitTime = 0f;
            gaps = Random.Range(minGaps, maxGaps);
        }

        if (transform.position.x < generationPoint.transform.position.x)
        {
            Vector3 translation = new Vector3(distanceBetween + groundWidth, 0f);
            transform.position += translation;

            if (tilesTilEnd > 0)
                tilesTilEnd--;

            if (gaps == 0)
            {
                Vector3Int currentCell = tileMap.WorldToCell(transform.position);
                tileMap.SetTile(currentCell, groundTile);

                if (tilesTilEnd == 0)
                {
                    // Instantiate an object to the right of the current object
                    Vector3 thePosition = transform.TransformPoint(house.transform.position);
                    house.transform.position = thePosition;
                    house.SetActive(true);
                    tilesTilEnd = -1;
                }
                    
            }
            else
                gaps--;
        }

        //Delete any ground tiles that have exited the screen.
        Vector3Int deletionCell = tileMap.WorldToCell(deletionPoint.position);
        tileMap.SetTile(deletionCell, null);

        elapsedGapWaitTime += Time.deltaTime;
    }
}
