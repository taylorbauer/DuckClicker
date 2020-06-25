using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Sprite tileSprite;

    // Maybe updated to move the tiles
    float scrollSpeed = 0;
    List<GameObject> tiles;
    

    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<GameObject>();
        float tileSpawnOffset = 5f;

        // Spawn new tiles
        float tileSpawnTracker = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        float tileSpawnTerminus = tileSpawnTracker + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + tileSpawnOffset;
        while (tileSpawnTracker <= tileSpawnTerminus) {
            GameObject newTile = new GameObject();
            newTile.AddComponent<SpriteRenderer>();
            newTile.GetComponent<SpriteRenderer>().sprite = tileSprite;
            newTile.transform.position = new Vector3(tileSpawnTracker - tileSpawnOffset / 2, Camera.main.ScreenToWorldPoint(Vector3.zero).y,0);
            newTile.transform.SetParent(this.transform, true);
            tiles.Add(newTile);
            tileSpawnTracker += newTile.GetComponent<SpriteRenderer>().bounds.size.x;
        }
        Debug.Log(tiles.Count + " tiles created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
