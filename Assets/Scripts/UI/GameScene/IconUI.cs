using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IconUI : MonoBehaviour, IIconUI
{
    [SerializeField] protected Transform template;

    public virtual List<IData> AllData()
    {
        return new List<IData>();
    }

    public object[] SerializeData(IData data)
    {
        return data.SerializeData(data);
    }

    public void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == template) continue;
            Destroy(child.gameObject);
        }
        List<IData> allData = AllData();
        for (int i = 0; i < allData.Count; i++)
        {
            if (i == 0)
            {
                template.GetComponent<ISingleIconUI>().SetSingleUI(SerializeData(allData[i]));
                template.gameObject.SetActive(true);
                continue;
            }

            Transform item = Instantiate(template, transform);
            item.GetComponent<ISingleIconUI>().SetSingleUI(SerializeData(allData[i]));
            item.gameObject.SetActive(true);
        }
    }
}
