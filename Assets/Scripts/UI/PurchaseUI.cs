using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseUI : MonoBehaviour
{
    public static event EventHandler OnPurchaseSuceess;
    public static PurchaseUI Instance { get; private set; }
    [SerializeField] private Button enterButton;
    // Start is called before the first frame update
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
        buyButton.onClick.AddListener(() =>
        {
            if (TryPurchase())
            {
                MoneyManager.Instance.PayMoney(purchaseIconUI.CalculatePrice());
                OnPurchaseSuceess?.Invoke(this, EventArgs.Empty);
            }
        });
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
    public Dictionary<KitchenObjectSO, int> GetNumDictionary()
    {
        return purchaseIconUI.GetNumDictionary();
    }
    public void ClearNumDictionary()
    {
        purchaseIconUI.ClearNumDictionary();
    }
}
