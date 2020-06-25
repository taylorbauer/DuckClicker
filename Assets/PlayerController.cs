using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerControllerInstance;
    public Sprite duckSprite;
    public GameObject duck { get; protected set; }
    public GameObject buttonPrefab;
    public GameObject textPrefab;
    public Canvas mainCanvas;
    public Canvas bottomButtons;

    public float duckOffsetY; // Y offset from center of screen.  Duck pivot is bottom center.

    public float animationDelay = 1.0f; // Delay on animation for spawning things in

    void Start()
    {
        playerControllerInstance = this;
        InitializeDuck();
        GenerateDuckButton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeDuck()
    {
        duck = new GameObject();
        duck.AddComponent<SpriteRenderer>();
        duck.GetComponent<SpriteRenderer>().sprite = duckSprite;
        duck.transform.SetParent(this.transform, true);
        duck.transform.position = new Vector3(0, duckOffsetY, 0);
        duck.name = "duck";
        duck.SetActive(false);
    }

    // Spawns duck and tiles, destroys button
    void StartGame(GameObject buttonToBeDestroyed)
    {
        destoryButton(buttonToBeDestroyed);
        Invoke("SpawnDuck", animationDelay);
    }

    void SpawnDuck()
    {
        Debug.Log("Spawning duck");
        duck.SetActive(true);
        TileController.tileControllerInstance.SpawnTiles();
        Invoke("SpawnBreadText", animationDelay * 2);
    }

    void destoryButton(GameObject button)
    {
        Destroy(button);
    }
    void GenerateDuckButton()
    {
        var duckButton = Instantiate(buttonPrefab, mainCanvas.transform.position, Quaternion.identity);
        duckButton.transform.SetParent(mainCanvas.transform);
        duckButton.AddComponent<UnityEngine.UI.Button>();
        var my_button = duckButton.GetComponent<UnityEngine.UI.Button>();
        my_button.onClick.AddListener(() => StartGame(duckButton));
    }

    void SpawnBreadText() {
        var text = Instantiate(textPrefab, bottomButtons.transform.position, Quaternion.identity);
        text.transform.SetParent(bottomButtons.transform);
        text.GetComponent<Text>().text = "Bread: 0";
        Invoke("SpawnBPSText", animationDelay / 2f);
    }

    void SpawnBPSText() {
        var text = Instantiate(textPrefab, bottomButtons.transform.position, Quaternion.identity);
        text.transform.SetParent(bottomButtons.transform);
        text.GetComponent<Text>().text = "Bread/sec: 0 BPS";
        Invoke("SpawnWalkButton", animationDelay / 2);
    }

    void SpawnWalkButton() {
        var walkButton = Instantiate(buttonPrefab, mainCanvas.transform.position, Quaternion.identity);
        walkButton.transform.SetParent(bottomButtons.transform);
        walkButton.AddComponent<UnityEngine.UI.Button>();
        walkButton.GetComponentInChildren<Text>().text = "Walk";
        var my_button = walkButton.GetComponent<UnityEngine.UI.Button>();
    }

    // TODO: Make these three UI elements all at once, immediately disable them, and then enable them on
    // the timer instead of what I'm doing now
}