using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

[Serializable]
public class MoneyManager : MonoBehaviour
{
    public event EventHandler OnMoneyChanged;
    public static MoneyManager Instance;

    [SerializeField] private float money = 100;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsDayOver())
        {
            AddMoney(PriceManager.Instance.GetEarnedMoney());
        }
    }

    public float GetMoney()
    {
        return money;
    }
    public void SetMoney(float amount)
    {
        money = amount;
        OnMoneyChanged?.Invoke(this, EventArgs.Empty);
    }
    public void PayMoney(float amount)
    {
        money -= amount;
        OnMoneyChanged?.Invoke(this, EventArgs.Empty);
    }
    public void AddMoney(float amount)
    {
        money += amount;
        OnMoneyChanged?.Invoke(this, EventArgs.Empty);
    }
}
