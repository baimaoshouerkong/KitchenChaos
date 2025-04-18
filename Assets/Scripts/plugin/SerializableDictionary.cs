using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver, IEnumerable<KeyValuePair<TKey, TValue>>
{
    [SerializeField] private List<SerializableKeyValuePair> list = new List<SerializableKeyValuePair>();
    private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

    [Serializable]
    public struct SerializableKeyValuePair
    {
        public TKey Key;
        public TValue Value;
    }

    private bool isDirty = true;

    public Dictionary<TKey, TValue> Dictionary => dictionary;

    // 实现 IEnumerable<KeyValuePair<TKey, TValue>> 接口
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }
    // 实现 IEnumerable 接口
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    // 从字典向内部列表序列化
    public void OnBeforeSerialize()
    {
        if (isDirty)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var kvp = list[i];
                if (kvp.Key != null && dictionary.ContainsKey(kvp.Key))
                {
                    list[i] = new SerializableKeyValuePair
                    {
                        Key = kvp.Key,
                        Value = dictionary[kvp.Key]
                    };
                }
            }
            isDirty = false;
        }
    }

    // 从内部列表向字典反序列化
    public void OnAfterDeserialize()
    {
        dictionary.Clear();
        foreach (var kvp in list)
        {
            if (kvp.Key != null && !dictionary.ContainsKey(kvp.Key))
            {
                dictionary[kvp.Key] = kvp.Value;
            }
        }
        isDirty = true;
    }

    // 字典接口的包装方法
    public void Add(TKey key, TValue value) => dictionary.Add(key, value);
    public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);
    public bool Remove(TKey key) => dictionary.Remove(key);
    public bool TryGetValue(TKey key, out TValue value) => dictionary.TryGetValue(key, out value);
    public void Clear() => dictionary.Clear();
    public void SetValue(TKey key, TValue value)
    {
        if (dictionary.ContainsKey(key))
        {
            dictionary[key] = value;
        }
    }

    public int Count => dictionary.Count;

    // 索引器
    public TValue this[TKey key]
    {
        get => dictionary[key];
        set => dictionary[key] = value;
    }
}