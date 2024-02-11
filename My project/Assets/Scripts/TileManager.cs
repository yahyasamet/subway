using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<GameObject> activeTiles = new List<GameObject>();
    public GameObject[] tilePrefabs;

    public float tileLength = 30;
    public int numberOfTiles = 6;

    public float zSpawn = 0;

    public Transform playerTransform;

    private int previousIndex;

    void Start()
    {
        
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }

        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        if (playerTransform.position.z - 35 >= zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
            
        }

    }

    public void SpawnTile(int titleIndex)
    {
        GameObject go = Instantiate(tilePrefabs[titleIndex],transform.forward*zSpawn,transform.rotation);
 

        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}