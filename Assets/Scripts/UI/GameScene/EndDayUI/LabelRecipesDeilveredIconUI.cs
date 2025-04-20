using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;


public class LabelRecipesDeilveredIconUI : IconUI
{
    private List<RecipeSO> recipeSOList;
    private void Start()
    {
        Hide();
        recipeSOList = new List<RecipeSO>();
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
            Show();
            recipeSOList = DeliveryManager.Instance.GetSuccessRecipeSOList();
            UpdateVisual();
        }
        else
        {
            Hide();
            recipeSOList.Clear();
            UpdateVisual();
        }
    }
    public override List<IData> AllData()
    {
        Debug.Log("AllData");
        List<IData> allData = new List<IData>();
        foreach (RecipeSO recipeSO in recipeSOList)
        {
            Debug.Log(recipeSO.recipeName);
            allData.Add(new LabelRecipesDeilveredIconUIData
            {
                name = recipeSO.recipeName,
                price = PriceManager.Instance.GetRecipePrice(recipeSO).ToString(),
                recipeSO = recipeSO,
            });
        }
        return allData;
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
