using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreIconUI : MonoBehaviour
{
    [SerializeField] private Transform template;
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


    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == template) continue;
            Destroy(child.gameObject);
        }
        int flag = 1;
        Dictionary<KitchenObjectSO, int> priceDictionary = StoreManager.Instance.GetStoreItemDictonary();
        foreach (KeyValuePair<KitchenObjectSO, int> price in priceDictionary)
        {
            if (flag == 1)
            {
                template.GetComponent<StoreSingleIconUI>().SetKitchenObjectSO(price.Value.ToString(), price.Key);
                flag = 0;
                template.gameObject.SetActive(true);
                continue;
            }

            Transform item = Instantiate(template, transform);
            item.GetComponent<StoreSingleIconUI>().SetKitchenObjectSO(price.Value.ToString(), price.Key);
            item.gameObject.SetActive(true);
        }
    }
    private void StoreManager_OnStoreItemChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
}
