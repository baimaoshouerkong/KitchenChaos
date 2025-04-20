using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Play.Publisher.Editor;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class SaveData
{
    public DayManager dayManager;
    public MoneyManager moneyManager;
    public PriceManager priceManager;
    public StoreManager storeManager;
    public SaveData(string a)
    {
        dayManager = DayManager.Instance;
        moneyManager = MoneyManager.Instance;
        priceManager = PriceManager.Instance;
        storeManager = StoreManager.Instance;
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
        Debug.Log(json);
        System.IO.File.WriteAllText(filename, json);
    }
    public void LoadGame()
    {
        if (System.IO.File.Exists(filename))
        {
            string json = System.IO.File.ReadAllText(filename);
            Debug.Log(json);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            DayManager.Instance = saveData.dayManager;
            MoneyManager.Instance = saveData.moneyManager;
            PriceManager.Instance = saveData.priceManager;
            StoreManager.Instance = saveData.storeManager;
        }
    }

}
