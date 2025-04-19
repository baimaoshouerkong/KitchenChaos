using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class PurchaseIconUIData : IData
{
    public KitchenObjectSO kitchenObjectSO;
    public float price;

    public PurchaseIconUIData(KitchenObjectSO kitchenObjectSO, float price)
    {
        this.kitchenObjectSO = kitchenObjectSO;
        this.price = price;
    }
    public object[] SerializeData(IData data)
    {
        return new object[] { ((PurchaseIconUIData)data).kitchenObjectSO, ((PurchaseIconUIData)data).price.ToString() };
    }
}
public class PurchaseSingleIconUI : MonoBehaviour,ISingleIconUI
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
    private void OnDestroy() {
        inputFieldUI.InputFieldUI_OnValueChanged -= OnInputFieldValueChanged;    
    }

    public void OnInputFieldValueChanged(object sender, int value)
    {
        num = value;
        PurchaseUI.Instance.GetNumDictionary()[kitchenObjectSO] = value;
    }

    public void SetSingleUI(params object[] args)
    {
        kitchenObjectSO = (KitchenObjectSO)args[0];
        priceText.text = (string)args[1];
        image.sprite = kitchenObjectSO.sprite;
    }
}
