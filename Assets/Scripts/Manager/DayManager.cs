using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DayManager : MonoBehaviour
{
    public static DayManager Instance;
    [SerializeField] private int dayCount = 1;
    private void Awake()
    {
        Instance = this;
    }
    public int GetDayCount()
    {
        return dayCount;
    }
    public void SetDayCount(int count)
    {
        dayCount = count;
    }
   
}
