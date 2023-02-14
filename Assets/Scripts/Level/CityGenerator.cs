using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    [SerializeField] float tileWidth = 100.0f;
    [SerializeField] List<GameObject> tilePrefabs = new List<GameObject>();
    [SerializeField] bool randomSeed = true;
    [SerializeField] int seed;
    [SerializeField] int rowLength = 8;
    [SerializeField] int rowHeight = 8; //yes, one should be row and one should be column. Who cares
    [SerializeField] GameObject[,] tiles;
    [SerializeField] float currentXPos = 0, currentYPos = 0;

    void Start()
    {
        GenerateLevel();
    }

    void Update()
    {
        
    }

    void GenerateLevel()
    {
        if (randomSeed == false)
        {
            Random.InitState(seed);
        }
        tiles = new GameObject[rowLength, rowHeight];

        for (int x = 0; x < rowLength; x++)
        {
            currentXPos += tileWidth;
            currentYPos = 0;
            for (int y = 0; y < rowHeight; y++)
            {
                int rand = Random.Range(0, tilePrefabs.Count);
                Vector3 pos = new(tileWidth * x, 0, tileWidth * y);
                tiles[x,y] = Instantiate(tilePrefabs[rand], pos, Quaternion.identity);
                tiles[x, y].name = string.Format("Tile x{0} y{1}", x, y);
                currentYPos += tileWidth;
                rand = Random.Range(1, 4);
                tiles[x, y].transform.Rotate(new Vector3(0, rand * 90, 0));
            }
        }
    }
}
