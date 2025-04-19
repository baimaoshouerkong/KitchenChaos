using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private void Start()
    {
        // Set the initial money text
        UpdateMoneyText();

        MoneyManager.Instance.OnMoneyChanged += MoneyManager_OnMoneyChanged;
    }
    private void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        MoneyManager.Instance.OnMoneyChanged -= MoneyManager_OnMoneyChanged;
    }
    private void UpdateMoneyText()
    {
        // Update the money text with the current money value
        moneyText.text = MoneyManager.Instance.GetMoney().ToString("0.00");
    }
    private void MoneyManager_OnMoneyChanged(object sender, System.EventArgs e)
    {
        // Update the money text when the money changes
        UpdateMoneyText();
    }
}
