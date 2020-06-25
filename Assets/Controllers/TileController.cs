using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Sprite tileSprite;

    public static TileController tileControllerInstance;

    // Maybe updated to move the tiles
    float scrollSpeed = 0;
    List<GameObject> tiles;
    float tile_Y;  // Y coordinate to spawn tiles at
    float tileSpawnOffset; // Offsets the first spawn to the left (and adjusts the last accordingly)

    public float animationDelay = 1.0f; // Delay on animation for spawning things in

    // Start is called before the first frame update
    void Start()
    {
        tileControllerInstance = this;
        tiles = new List<GameObject>();
        tileSpawnOffset = 5f;  
        tile_Y = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTiles() {
        Invoke("_SpawnTiles", animationDelay);
    }
    void _SpawnTiles() {
        float tileSpawnTracker = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        float tileSpawnTerminus = tileSpawnTracker + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + tileSpawnOffset;
        while (tileSpawnTracker <= tileSpawnTerminus) {
            GameObject newTile = new GameObject();
            newTile.AddComponent<SpriteRenderer>();
            newTile.GetComponent<SpriteRenderer>().sprite = tileSprite;
            newTile.transform.position = new Vector3(tileSpawnTracker - tileSpawnOffset / 2, tile_Y, 0);
            newTile.transform.SetParent(this.transform, true);
            tiles.Add(newTile);
            tileSpawnTracker += newTile.GetComponent<SpriteRenderer>().bounds.size.x;
        }
        Debug.Log(tiles.Count + " tiles created");
    }
}
