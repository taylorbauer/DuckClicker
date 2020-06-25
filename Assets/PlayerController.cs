using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite duckSprite;
    public GameObject duck {get; protected set;}
    // Start is called before the first frame update
    void Start()
    {
        duck = new GameObject();
        duck.AddComponent<SpriteRenderer>();
        duck.GetComponent<SpriteRenderer>().sprite = duckSprite;
        duck.transform.SetParent(this.transform, true);
        duck.transform.position = new Vector3 (0, -0.11f, 0);
        duck.name = "duck";
        duck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnDuck() {
        duck.SetActive(true);
    }
}
