using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private GameObject stoveOnVisualGameObject;
    [SerializeField] private GameObject particlesGameObject;
    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisuals = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        stoveOnVisualGameObject.SetActive(showVisuals);
        particlesGameObject.SetActive(showVisuals);
    }
}