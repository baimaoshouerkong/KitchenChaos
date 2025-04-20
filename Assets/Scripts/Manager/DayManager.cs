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
        Debug.Log("GetDay Count: " + dayCount);
        return dayCount;

    }
    public void SetDayCount(int count)
    {
        dayCount = count;
    }
    public void AddDayCount()
    {
        dayCount += 1;
        Debug.Log("Day Count: " + dayCount);
    }

}
