using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IData
{
    public object[] SerializeData(IData data);
}