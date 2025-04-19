using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class DayOverUI : MonoBehaviour
{
  
    private void Start()
    {
        
        Hide();
    }
    private void OnDestroy()
    {

    }

   
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
