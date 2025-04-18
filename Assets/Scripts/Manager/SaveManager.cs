using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Play.Publisher.Editor;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class SaveData
{
    public float money;
    public int dayCount;
    public SerializableDictionary<KitchenObjectSO, float> rawPriceDict;
    public SerializableDictionary<KitchenObjectSO, int> storeItemDictionary;
    public SaveData(string a)
    {
        money = MoneyManager.Instance.GetMoney();
        dayCount = DayManager.Instance.GetDayCount();
        rawPriceDict = PriceManager.Instance.GetRawPriceDictionary();
        storeItemDictionary = StoreManager.Instance.GetStoreItemDictonary();
    }
    public SaveData()
    {
        
    }

}



public class SaveManager : MonoBehaviour
{
    private string filename;
    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        filename = "./Assets/Save/save.json";
    }
    private void Start()
    {
        if(Loader.gameType==Loader.GameType.Load)
        {
            LoadGame();
        }
    }
    public void SaveGame()
    {
        string json = JsonUtility.ToJson(new SaveData("save"));
        System.IO.File.WriteAllText(filename, json);
    }
    public void LoadGame()
    {
        if (System.IO.File.Exists(filename))
        {
            string json = System.IO.File.ReadAllText(filename);
            Debug.Log(json);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            foreach (KeyValuePair<KitchenObjectSO, int> item in saveData.storeItemDictionary)
            {
                Debug.Log(item.Key + " " + item.Value);
            }
            MoneyManager.Instance.SetMoney(saveData.money);
            DayManager.Instance.SetDayCount(saveData.dayCount);
            PriceManager.Instance.LoadData(saveData.rawPriceDict);
            StoreManager.Instance.LoadData(saveData.storeItemDictionary);
        }
    }

}
