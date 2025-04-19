using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StoreIconUIData : IData
{
    public KitchenObjectSO kitchenObjectSO;
    public string text;
    public StoreIconUIData(KitchenObjectSO kitchenObjectSO, string text)
    {
        this.kitchenObjectSO = kitchenObjectSO;
        this.text = text;
    }

    public object[] SerializeData(IData data)
    {
        StoreIconUIData storeIconUIData = (StoreIconUIData)data;
        return new object[] { storeIconUIData.kitchenObjectSO, storeIconUIData.text };

    }
}
    public class StoreSingleIconUI : MonoBehaviour, ISingleIconUI
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image background;

        public void SetSingleUI(params object[] args)
        {
            KitchenObjectSO kitchenObjectSO = args[0] as KitchenObjectSO;
            image.sprite = kitchenObjectSO.sprite;
            this.text.text = args[1].ToString();
        }
    }

