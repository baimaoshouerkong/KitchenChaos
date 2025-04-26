using Systeml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonParser : MonoBehaviour
{
    public static JsonParser Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void ParseJson(string json)
    {

    }