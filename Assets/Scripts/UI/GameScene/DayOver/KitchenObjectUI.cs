using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class KitchenObjectUI : IconUI
{
    private  RecipeSO recipeSO;
    public void SetRecipeSO(RecipeSO recipeSO)
    {
        this.recipeSO = recipeSO;
        UpdateVisual();
    }
    
    public override List<IData> AllData()
    {
        List<IData> allData = new List<IData>();
        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList)
        {
            allData.Add(new KitchenObjectUIData
            {
                sprite = kitchenObjectSO.sprite,
            });
        }
        return allData;
    }
}

