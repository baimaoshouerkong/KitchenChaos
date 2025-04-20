using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class LabelRecipesDeilveredIconUIData : IData
{
    public string name;
    public string price;
    public RecipeSO recipeSO;
    public object[] SerializeData(IData data)
    {
        return new object[] { name, price, recipeSO };
    }
}
public class LabelRecipesDeilveredSingleIconUI : MonoBehaviour, ISingleIconUI
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private KitchenObjectUI kitchenObjectUI;
    public void SetSingleUI(params object[] args)
    {
        nameText.text = args[0] as string;
        priceText.text = args[1] as string;
        kitchenObjectUI.SetRecipeSO(args[2] as RecipeSO);
    }
}
