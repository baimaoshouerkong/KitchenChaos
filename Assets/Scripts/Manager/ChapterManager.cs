using System;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public static ChapterManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}


