using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;


    public static KitchenGameManager Instance { get; private set; }
    
    private enum State
    {
        Purchase,
        CountdownToStart,
        GamePlaying,
        EndDay,
        GameOver,
    }
    private State state;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 180f;
    private bool isGamePaused = false;
    private void Awake()
    {
        Instance = this;
        state = State.Purchase;
    }
    private void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }
    
    private void OnDestroy()
    {
        GameInput.Instance.OnPauseAction -= GameInput_OnPauseAction;
    }

    public void StartGame()
    {
        state = State.CountdownToStart;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    private void Update()
    {
        switch (state)
        {
            case State.Purchase:
                // Handle purchase logic here
                PurchaseUI.Instance.Show();
                break;
            case State.CountdownToStart:
                // Start the game countdown
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    gamePlayingTimer = gamePlayingTimerMax;
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                // Game logic goes here
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.EndDay;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.EndDay:
                // Handle end day logic here
                
                break;
            case State.GameOver:
                // Handle game over logic here
                break;
        }
    }



    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public bool IsCountdownToStartActive()
    {
        return state == State.CountdownToStart;
    }
    public bool IsGameOver()
    {
        return state == State.GameOver;
    }
    public bool IsDayOver()
    {
        return state == State.EndDay;
    }



    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }
    public float GetGamePlayingTimerNormalized()
    {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax);
    }
    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f; // Pause the game
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }
    

}
