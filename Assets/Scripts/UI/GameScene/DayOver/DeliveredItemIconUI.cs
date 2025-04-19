using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;


public class DeliveredItemIconUI : IconUI
{
    private List<RecipeSO> recipeSOList;
    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
    }
    private void OnDestroy()
    {
        KitchenGameManager.Instance.OnStateChanged -= KitchenGameManager_OnStateChanged;
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsDayOver())
        {
            recipeSOList = DeliveryManager.Instance.GetSuccessRecipeSOList();
            UpdateVisual();
        }
    }
    public override List<IData> AllData()
    {
        List<IData> allData = new List<IData>();
        foreach (RecipeSO recipeSO in recipeSOList)
        {
            allData.Add(new DeliveredItemIconUIData
            {
                name = recipeSO.recipeName,
                price = PriceManager.Instance.GetRecipePrice(recipeSO).ToString(),
                recipeSO = recipeSO,
            });
        }
        return allData;
    }
}
