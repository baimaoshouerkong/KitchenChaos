using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class KitchenObjectUIData : IData
{
    public Sprite sprite;
    public object[] SerializeData(IData data)
    {
        return new object[] { sprite };
    }
}

public class KitchenObjectSingleUI : ISingleIconUI
{
    [SerializeField] private Image image;

    public void SetSingleUI(params object[] args)
    {
        image.sprite = args[0] as Sprite;
    }
}
