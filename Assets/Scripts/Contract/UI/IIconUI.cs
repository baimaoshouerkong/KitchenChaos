using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIconUI
{
    public List<IData> AllData();
    public object[] SerializeData(IData data);
}
