using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;
    
    private void Awake()
    {

        resumeButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        optionsButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Hide();
            OptionsUI.Instance.Show(Show);
        });
    }
    private void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        Hide();
    }
    private void OnDestroy()
    {
        KitchenGameManager.Instance.OnGamePaused -= KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused -= KitchenGameManager_OnGameUnpaused;
        resumeButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainMenuButton.GetComponent<Button>().onClick.RemoveAllListeners();
        optionsButton.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void KitchenGameManager_OnGamePaused(object sender, EventArgs e)
    {
        Show();
        resumeButton.Select();
    }

    private void Show()
    {
        gameObject.SetActive(true);

    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
