using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StoreManager : MonoBehaviour
{

    public event EventHandler OnStoreItemChanged;
    public static StoreManager Instance;
    [SerializeField] private SerializableDictionary<KitchenObjectSO, int> storeItemDictionary = new SerializableDictionary<KitchenObjectSO, int>();
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PurchaseUI.OnPurchaseSuceess += PurchaseUI_OnPurchaseSuceess;
    }

    public SerializableDictionary<KitchenObjectSO, int> GetStoreItemDictonary()
    {
        return storeItemDictionary;
    }
    private void PurchaseUI_OnPurchaseSuceess(object sender, EventArgs e)
    {
        AddStoreItem();
        OnStoreItemChanged?.Invoke(this, EventArgs.Empty);
    }
    private void AddStoreItem()
    {
        SerializableDictionary<KitchenObjectSO, int> dict = PurchaseUI.Instance.GetNumDictionary();
        foreach (KeyValuePair<KitchenObjectSO, int> item in dict)
        {
            storeItemDictionary[item.Key] += item.Value;
        }
    }
    internal void LoadData(SerializableDictionary<KitchenObjectSO, int> storeItemDictionary)
    {
        this.storeItemDictionary = storeItemDictionary;
        this.storeItemDictionary.OnBeforeSerialize();
        OnStoreItemChanged?.Invoke(this, EventArgs.Empty);
    }
}