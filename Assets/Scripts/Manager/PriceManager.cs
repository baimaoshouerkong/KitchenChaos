using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PriceManager : MonoBehaviour
{
    public static PriceManager Instance;
    [SerializeField] private List<RawPrice> rawPriceList;
    [Serializable]
    public class RawPrice
    {
        public KitchenObjectSO kitchenObjectSO;
        public float price;
    }

    public class RecipePrice
    {
        public float price;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }

    public Dictionary<KitchenObjectSO, float> GetRawPriceDictionary()
    {
        Dictionary<KitchenObjectSO, float> priceDictionary = new Dictionary<KitchenObjectSO, float>();
        foreach (RawPrice price in rawPriceList)
        {
            priceDictionary[price.kitchenObjectSO]= price.price;
        }
        return priceDictionary;
    }
}
