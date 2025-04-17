using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public float GetMoney()
    {
        return money;
    }
    public void PayMoney(float amount)
    {
        money -= amount;
        Debug.Log("PayMoney" + amount);
        OnMoneyChanged?.Invoke(this, EventArgs.Empty);
    }
    public void AddMoney(float amount)
    {
        money += amount;
        OnMoneyChanged?.Invoke(this, EventArgs.Empty);
    }
}
