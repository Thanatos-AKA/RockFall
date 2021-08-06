using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    //Ship prefab
    public GameObject shipPrefab;
    public Transform shipStartPoisition;
    public GameObject currentShip { get; private set; }

    //Station prefab
    public GameObject stationPrefab;
    public Transform stationStartPoisition;
    public GameObject currentStation { get; private set; }

    //Smooth camera
    public SmoothFollow cameraFollow;

    //UI
    public GameObject inGameUI;
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject mainMenuUI;

    //Other stuff
    public bool gameIsPlaying { get; private set; }

    public AsteroidSpawner asteroidSpawner;

    public bool paused;

    private void Start() {
        ShowMainMenu();
    }

    void showUI(GameObject newUI) {
        GameObject[] allUI = { inGameUI, pausedUI, gameOverUI, mainMenuUI };
        foreach(GameObject UIToHide in allUI) {
            UIToHide.SetActive(false);
        }

        newUI.SetActive(true);
    }

    public void ShowMainMenu() {
        showUI(mainMenuUI);

        gameIsPlaying = false;

        asteroidSpawner.spawnAsteriod = false;
    }

    public void StartGame() {
        showUI(inGameUI);

        gameIsPlaying = false;

        if(currentShip != null) {
            Destroy(currentShip);
        }

        if(currentStation != null) {
            Destroy(currentStation);
        }

        //Instantiate prefabs
        currentShip = Instantiate(shipPrefab);
        currentShip.transform.position = shipStartPoisition.position;
        currentShip.transform.rotation = shipStartPoisition.rotation;

        currentStation = Instantiate(stationPrefab);
        currentStation.transform.position = stationStartPoisition.position;
        currentStation.transform.rotation = stationStartPoisition.rotation;

        //Set Camera, asteroids, spawner
        cameraFollow.target = currentShip.transform;
        asteroidSpawner.spawnAsteriod = true;
        asteroidSpawner.target = currentStation.transform;
    }

    public void GameOver() {
        showUI(gameOverUI);

        //stop anything
        gameIsPlaying = false;

        if(currentShip != null) {
            Destroy(currentShip);
        }

        if(currentStation != null) {
            Destroy(currentStation);
        }

        asteroidSpawner.spawnAsteriod = false;
        asteroidSpawner.DestroyAllAsteriods();
    }

    public void SetPaused(bool paused) {
        inGameUI.SetActive(!paused);
        pausedUI.SetActive(paused);

        if(paused) {
            Time.timeScale = 0.0f;
        }
        else {
            Time.timeScale = 1.0f;
        }
    }
}
