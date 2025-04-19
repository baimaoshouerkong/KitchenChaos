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
    public bool TryGetKithcenObjectSO(KitchenObjectSO kitchenObjectSO, int value)
    {
        if (storeItemDictionary[kitchenObjectSO]-value > 0)
        {
            storeItemDictionary[kitchenObjectSO] -= value;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LoadData(SerializableDictionary<KitchenObjectSO, int> storeItemDictionary)
    {
        this.storeItemDictionary = storeItemDictionary;
        OnStoreItemChanged?.Invoke(this, EventArgs.Empty);
    }

    public SerializableDictionary<KitchenObjectSO, int> GetStoreItemDictonary()
    {
        return storeItemDictionary;
    }

}