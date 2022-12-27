using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnStateChangend;


    private bool pause = false;

    public GameObject pauseUI;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        UpdateGameState(GameState.MainMenu);
        Debug.Log($"{State.ToString()}");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.State = GameManager.GameState.Paused;
            pause = !pause;
            if (pause)
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                GameManager.Instance.State = GameManager.GameState.InGame;
                pause = false;
                pauseUI.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

    public void ToMainMenu()
    {
        RestartGame();
    }

    public void StartGame()
    {
        UpdateGameState(GameState.InGame);
    }

    public void MainMenu()
    {
        UpdateGameState(GameState.MainMenu);

    }

    public void PausedGame()
    {
        UpdateGameState(GameState.Paused);
    }

    public void DeadGame()
    {
        UpdateGameState(GameState.InGame_dead);
    }

    public void RestartGame()
    {
       UpdateGameState(GameState.MainMenu);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }



    public void UpdateGameState(GameState newState)
    {
        Debug.Log($"State changet from {State} to {newState.ToString()}");
        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                break;
            case GameState.InGame:
                break;
            case GameState.InGame_dead:
                break;
            case GameState.Paused:
                break;
        }

        OnStateChangend?.Invoke(newState);
    }

    public enum GameState
    {
        MainMenu,
        InGame,
        InGame_dead,
        Paused,

    }
}
