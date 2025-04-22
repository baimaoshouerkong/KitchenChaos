using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuffManager : MonoBehaviour
{
    public static BuffManager Instance;


    void Awake()
    {
        Instance = this;
    }

}
