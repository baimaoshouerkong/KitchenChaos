using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class DayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayCountText;


    private void Start()
    {
        Show();
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
    
    }
    private void OnDestroy()
    {
        KitchenGameManager.Instance.OnStateChanged -= KitchenGameManager_OnStateChanged;
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsPurchase())
        {
            dayCountText.text = DayManager.Instance.GetDayCount().ToString();
            Show();
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