using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventTree
{
    public event EventHandler OnEventTreeChanged;
    public static EventTree Instance { get; private set; }
    public EventTreeNode root;
    public EventTreeNode currentNode;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        root = new EventTreeNode();
        currentNode = root;
    }
    //  从这里就是我的事件树 EventTreeNode 就是每天的事件
    //        /0\
    // -0-0-0     0-0-0-
    //        \0/
    public void AddChild(EventTreeNode child)
    {
        currentNode.Children.Add(child);
        child.Parent = currentNode;
        OnEventTreeChanged?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveChild(EventTreeNode child)
    {
        if (currentNode.Children.Contains(child))
        {
            currentNode.Children.Remove(child);
            child.Parent = null;
            OnEventTreeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public void SetCurrentNode(EventTreeNode node)
    {
        currentNode = node;
        OnEventTreeChanged?.Invoke(this, EventArgs.Empty);
    }
    public void ResetTree()
    {
        currentNode = root;
        OnEventTreeChanged?.Invoke(this, EventArgs.Empty);
    }
    
}