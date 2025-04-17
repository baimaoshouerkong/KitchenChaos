using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class PurchaseSingleIconUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private InputFieldUI inputFieldUI;
    private KitchenObjectSO kitchenObjectSO;
    private int num;
    private void Awake()
    {
        inputFieldUI.InputFieldUI_OnValueChanged += OnInputFieldValueChanged;
        num = 0;
    }
    public void SetKitchenObjectSO(string text, KitchenObjectSO kitchenObjectSO)
    {
        image.sprite = kitchenObjectSO.sprite;
        priceText.text = text;
        this.kitchenObjectSO = kitchenObjectSO;
    }
    public void OnInputFieldValueChanged(object sender, int value)
    {
        num = value;
        PurchaseUI.Instance.GetNumDictionary()[kitchenObjectSO] = value;
    }
}
