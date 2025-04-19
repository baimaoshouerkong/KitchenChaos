using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseUI : MonoBehaviour
{
    public static event EventHandler OnPurchaseSuceess;
    public static PurchaseUI Instance { get; private set; }
    [SerializeField] private Button enterButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button saveButton;
  
    [SerializeField] private Button buyButton;
    
    [SerializeField] private PurchaseIconUI purchaseIconUI;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Show();
        enterButton.onClick.AddListener(() =>
        {
            KitchenGameManager.Instance.StartGame();
            Hide();
        });
        exitButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
            Hide();
        });
        saveButton.onClick.AddListener(() =>
        {
            SaveManager.Instance.SaveGame();
        });
        buyButton.onClick.AddListener(() =>
        {
            if (TryPurchase())
            {
                MoneyManager.Instance.PayMoney(purchaseIconUI.CalculatePrice());
                OnPurchaseSuceess?.Invoke(this, EventArgs.Empty);
            }
        });
    }
    private void OnDestroy()
    {
        enterButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        saveButton.onClick.RemoveAllListeners();
        buyButton.onClick.RemoveAllListeners();
    }

    private bool TryPurchase()
    {
        return (MoneyManager.Instance.GetMoney() - purchaseIconUI.CalculatePrice()) >= 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    public SerializableDictionary<KitchenObjectSO, int> GetNumDictionary()
    {
        return purchaseIconUI.GetNumDictionary();
    }
    public void ClearNumDictionary()
    {
        purchaseIconUI.ClearNumDictionary();
    }
}
