using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    protected void Bind<T>(Type type) where T : Component
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        for (int i = 0; i < names.Length; i++)
            objects[i] = gameObject.FindChild<T>(names[i]);
        _objects.Add(typeof(T), objects);
    }

    protected T Get<T>(int id) where T : Component
    {
        if (_objects.ContainsKey(typeof(T)))
            return _objects[typeof(T)][id] as T;
        return null;
    }
}
