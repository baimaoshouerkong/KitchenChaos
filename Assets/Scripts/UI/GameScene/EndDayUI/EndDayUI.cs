using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EndDayUI : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button nextDayButton;
    private void Start()
    {
        Hide();
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        exitButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
            Hide();
        });
        saveButton.onClick.AddListener(() =>
        {
            SaveManager.Instance.SaveGame();
        });
        nextDayButton.onClick.AddListener(() =>
        {
            KitchenGameManager.Instance.NextDay();
        });
    }



    private void OnDestroy()
    {
        KitchenGameManager.Instance.OnStateChanged -= KitchenGameManager_OnStateChanged;
        exitButton.onClick.RemoveAllListeners();
        saveButton.onClick.RemoveAllListeners();
        nextDayButton.onClick.RemoveAllListeners();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsDayOver())
        {
            Show();
            DeliveryManager.Instance.ClearWaitingRecipeSOList();
        }
        else
        {
            Hide();
        }
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
