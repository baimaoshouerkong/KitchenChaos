using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    public static PriceManager Instance;
    [SerializeField] private SerializableDictionary<KitchenObjectSO, float> rawPriceDict = new SerializableDictionary<KitchenObjectSO, float>();
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }

    public SerializableDictionary<KitchenObjectSO, float> GetRawPriceDictionary()
    {
        return rawPriceDict;
    }
    public void LoadData(SerializableDictionary<KitchenObjectSO, float> dict)
    {
        rawPriceDict = dict;
    }

}
