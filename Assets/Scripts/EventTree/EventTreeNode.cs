using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  class EventTreeNode
{
    public EventTreeNode Parent { get; set; }
    public List<EventTreeNode> Children { get; private set; }
    public bool IsHappened = false;
}