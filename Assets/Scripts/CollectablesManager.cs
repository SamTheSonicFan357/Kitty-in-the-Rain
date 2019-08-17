using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class CollectablesManager : MonoBehaviour
{
    public Tilemap tileMap;
    public CollectablesBrush brush;
    public GameObject[] generationPoints;
    //public Transform deletionPoint;
    public float distanceBetween;
    public float minStartSpawnTime = 1;
    public float maxStartSpawnTime = 3;
    public int minCollectables = 5;
    public int maxCollectables = 8;

    private float elapsedSpawnWaitTime;
    private float spawnWaitTime;
    private int numOfCollectables = 0;
    private const int platformWidth = 1;

    private void Update()
    {
        if (elapsedSpawnWaitTime > spawnWaitTime)
        {
            spawnWaitTime = Random.Range(minStartSpawnTime, maxStartSpawnTime);
            elapsedSpawnWaitTime = 0f;
            numOfCollectables = Random.Range(minCollectables, maxCollectables);
        }

        if (numOfCollectables > 0)
        {
            int randIndex = Random.Range(0, generationPoints.Length);
            GameObject generationPoint = generationPoints[randIndex];

            if (transform.position.x < generationPoint.transform.position.x)
            {
                Vector3Int currentCell = tileMap.WorldToCell(generationPoint.transform.position + new Vector3(0f, 1f));
                brush.Paint(tileMap, currentCell);
                Vector3 translation = new Vector3(distanceBetween + platformWidth, 0f);
                transform.position += translation;
                numOfCollectables--;
            }
        }

        elapsedSpawnWaitTime += Time.deltaTime;
    }
}
