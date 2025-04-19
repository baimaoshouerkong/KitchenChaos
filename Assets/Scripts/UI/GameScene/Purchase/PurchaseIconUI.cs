using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseIconUI : IconUI
{
    [SerializeField] private GameObject purchaseUI;
    [SerializeField] private PurchaseSingleIconUI purchaseSingleIconUI;
    private SerializableDictionary<KitchenObjectSO, float> priceDictionary = new SerializableDictionary<KitchenObjectSO, float>();
    private SerializableDictionary<KitchenObjectSO, int> numDictionary = new SerializableDictionary<KitchenObjectSO, int>();

    private void Awake()
    {
        template.gameObject.SetActive(false);
        purchaseUI.SetActive(false);
    }
    private void Start()
    {
        priceDictionary = PriceManager.Instance.GetRawPriceDictionary();
        UpdateVisual();
    }

    public float CalculatePrice()
    {
        float totalPrice = 0;
        foreach (var item in numDictionary)
        {
            if (priceDictionary.ContainsKey(item.Key))
            {
                totalPrice += priceDictionary[item.Key] * item.Value;
            }
        }
        return totalPrice;
    }
    private void Show()
    {
        gameObject.SetActive(true);
        purchaseUI.SetActive(true);
        template.gameObject.SetActive(true);
    }
    private void Hide()
    {
        foreach (Transform child in transform)
        {
            if (child == template) continue;
            Destroy(child.gameObject);
        }
        template.gameObject.SetActive(false);
        gameObject.SetActive(false);
        purchaseUI.SetActive(false);
    }
    public SerializableDictionary<KitchenObjectSO, int> GetNumDictionary()
    {
        return numDictionary;
    }
    public void ClearNumDictionary()
    {
        foreach (KeyValuePair<KitchenObjectSO, int> item in numDictionary)
        {
            numDictionary[item.Key] = 0;
        }
    }
    public override List<IData> AllData()
    {
        List<IData> allData = new List<IData>();
        foreach (KeyValuePair<KitchenObjectSO, float> item in priceDictionary)
        {
            allData.Add(new PurchaseIconUIData(item.Key, item.Value));
        }
        return allData;
    }
}

