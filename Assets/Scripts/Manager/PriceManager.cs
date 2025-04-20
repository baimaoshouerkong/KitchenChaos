using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[Serializable]
public class PriceManager : MonoBehaviour
{
    public static PriceManager Instance;
    //原材料的价格
    [SerializeField] private SerializableDictionary<KitchenObjectSO, float> rawPriceDict;
    //原材料附加价格
    [SerializeField] private SerializableDictionary<KitchenObjectSO, float> risePriceDict;
    //食谱的价格
    [SerializeField] private SerializableDictionary<RecipeSO, float> recipePriceDict;
    //食谱列表
    [SerializeField] private RecipeListSO recipeList;

    [SerializeField] private float riseRate;

    private void Awake()
    {
        Instance = this;
        riseRate = 1f;
    }
    private void Start()
    {
        CountRecipePriceDict();
    }


    public SerializableDictionary<KitchenObjectSO, float> GetRawPriceDictionary()
    {
        return rawPriceDict;
    }
    public void LoadData(SerializableDictionary<KitchenObjectSO, float> dict)
    {
        rawPriceDict = dict;
    }

    public void CountRecipePriceDict()
    {
        foreach (var item in recipeList.recipeSOList)
        {
            recipePriceDict[item] = CountRecipeDict(item);
        }
    }
    public float CountRecipeDict(RecipeSO recipe)
    {
        float price = 0f;
        foreach (var item in recipe.kitchenObjectSOList)
        {
            price += risePriceDict[item] * riseRate;
        }
        return price;
    }
    public float GetRecipePrice(RecipeSO recipe)
    {
        if (recipePriceDict.ContainsKey(recipe))
        {
            return recipePriceDict[recipe];
        }
        else
        {
            Debug.LogError("Recipe not found in price dictionary.");
            return 0f;
        }
    }
    public float GetEarnedMoney()
    {
        float totalPrice = 0f;
        foreach (var item in DeliveryManager.Instance.GetSuccessRecipeSOList())
        {
            totalPrice += recipePriceDict[item];
        }
        return totalPrice;
    }
}
