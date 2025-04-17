using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
  [SerializeField] private Image timerImage;
  private void Awake()
  {
    Hide();
  }
  private void Start()
  {
    KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
  }
  private void Update()
  {
    timerImage.fillAmount = KitchenGameManager.Instance.GetGamePlayingTimerNormalized();
  }
  private void Show()
  {
    gameObject.SetActive(true);
  }
  private void Hide()
  {
    gameObject.SetActive(false);
  }
  private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
  {
    if (KitchenGameManager.Instance.IsGamePlaying())
    {
      Show();
    }
    else
    {
      Hide();
    }
  }
}
