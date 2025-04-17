using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoreManager : MonoBehaviour
{
    public event EventHandler OnStoreItemChanged;
    public static StoreManager Instance { get; private set; }
    [SerializeField] private List<StoreItem> storeItemlist;
    private Dictionary<KitchenObjectSO, int> storeItemDictionary = new Dictionary<KitchenObjectSO, int>();

    [Serializable]
    public struct StoreItem
    {
        public KitchenObjectSO kitchenObjectSO;
        public int storeNum;
    }

    private void Awake()
    {
        Instance = this;
        PurchaseUI.OnPurchaseSuceess += PurchaseUI_OnPurchaseSuceess;
    }

    private void Start()
    {
        UpdateStoreItem();
    }

    public Dictionary<KitchenObjectSO, int> GetStoreItemDictonary()
    {
        return storeItemDictionary;
    }
    private void PurchaseUI_OnPurchaseSuceess(object sender, EventArgs e)
    {
        AddStoreItem();
        UpdateStoreItemDictionary();
        OnStoreItemChanged?.Invoke(this, EventArgs.Empty);
    }
    private void AddStoreItem()
    {
        Dictionary<KitchenObjectSO, int> dict = PurchaseUI.Instance.GetNumDictionary();
        foreach (KeyValuePair<KitchenObjectSO, int> item in dict)
        {
            storeItemDictionary[item.Key] += item.Value;
            // Debug.Log(item.Key + " " + item.Value);
        }

    }

    private void UpdateStoreItem()
    {
        foreach (StoreItem item in storeItemlist)
        {
            storeItemDictionary[item.kitchenObjectSO] = item.storeNum;
        }
    }
    private  void UpdateStoreItemDictionary()
    {
        for (int i = 0; i < storeItemlist.Count; i++)
        {
            StoreItem item = storeItemlist[i];
            item.storeNum = storeItemDictionary[item.kitchenObjectSO];
            storeItemlist[i] = item;  // This assigns the modified struct back to the list
        }
    }
}