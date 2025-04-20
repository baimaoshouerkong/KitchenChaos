using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EarnedMoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI earnedMoneyText;
    private void Start()
    {
        Hide();
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsDayOver())
        {
            Show();
            earnedMoneyText.text = PriceManager.Instance.GetEarnedMoney().ToString();
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

