using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;
    private Transform playerTransform;
    private float spawnZ = -1000f;
    public float safeZone = 1000.0f;
    private float tileLength = 1000f;
    private int amnTilesOnScreen = 3;
    private int lastTileIndex = 0;
    private List<GameObject> activeTiles;
    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    void  SpawnTile(int prefabInde = -1)
    {
        GameObject go;
        go = Instantiate(tiles[RandomTileIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go); 
    }
    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomTileIndex()
    {
        if(tiles.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastTileIndex;
        while(randomIndex == lastTileIndex)
        {
            randomIndex = Random.Range(0, tiles.Length);
        }

        lastTileIndex = randomIndex;
        return randomIndex;
    }
}
