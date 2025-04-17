using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseIconUI : MonoBehaviour
{
    [SerializeField] private Transform template;
    [SerializeField] private GameObject purchaseUI;
    [SerializeField] private PurchaseSingleIconUI purchaseSingleIconUI;
    private Dictionary<KitchenObjectSO, float> priceDictionary = new Dictionary<KitchenObjectSO, float>();
    private Dictionary<KitchenObjectSO, int> numDictionary = new Dictionary<KitchenObjectSO, int>();
    
    private void Awake()
    {
        template.gameObject.SetActive(false);
        purchaseUI.SetActive(false);
    }
    private void Start()
    {
        UpdateVisual();
    }


    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == template) continue;
            Destroy(child.gameObject);
        }
        int flag = 1;
        priceDictionary = PriceManager.Instance.GetRawPriceDictionary();
        foreach (KeyValuePair<KitchenObjectSO, float> price in priceDictionary)
        {
            if (flag == 1)
            {
                template.GetComponent<PurchaseSingleIconUI>().SetKitchenObjectSO(price.Value.ToString(), price.Key);
                flag = 0;
                template.gameObject.SetActive(true);
                continue;
            }
            Transform item = Instantiate(template, transform);
            item.GetComponent<PurchaseSingleIconUI>().SetKitchenObjectSO(price.Value.ToString(), price.Key);
            item.gameObject.SetActive(true);
        }
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
    public Dictionary<KitchenObjectSO, int> GetNumDictionary()
    {
        return numDictionary;
    }
    public void ClearNumDictionary()
    {
        foreach(KeyValuePair<KitchenObjectSO, int> item in numDictionary)
        {
            numDictionary[item.Key] = 0;
        }
    }
}

