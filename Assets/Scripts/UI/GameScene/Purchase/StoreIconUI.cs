using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreIconUI : IconUI
{
    private void Awake()
    {
        template.gameObject.SetActive(false);
    }
    private void Start()
    {
        StoreManager.Instance.OnStoreItemChanged += StoreManager_OnStoreItemChanged;
        template.gameObject.SetActive(true);
        UpdateVisual();
    }
    private void OnDestroy()
    {
        StoreManager.Instance.OnStoreItemChanged -= StoreManager_OnStoreItemChanged;
    }

    private void StoreManager_OnStoreItemChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    public override List<IData> AllData()
    {
        List<IData> allData = new List<IData>();
        foreach (var item in StoreManager.Instance.GetStoreItemDictonary())
        {
            StoreIconUIData storeIconUIData = new StoreIconUIData(item.Key,item.Value.ToString());
            allData.Add(storeIconUIData);
        }
        return allData;
    }
}
