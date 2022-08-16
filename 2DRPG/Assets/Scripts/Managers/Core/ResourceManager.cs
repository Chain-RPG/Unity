using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string name) where T : Object
    {
        return Resources.Load<T>(name);
    }

    public GameObject Instantiate(string name)
    {
        if (name == null)
            return null;
        string path = name;
        if (!path.StartsWith("Prefabs/"))
            path = $"Prefabs/{name}";
        GameObject origin = Load<GameObject>(path);
        if (origin == null)
            return null;
        GameObject go = GameObject.Instantiate(origin);
        go.name = origin.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
        {
            return;
        }
        Object.Destroy(go);
    }
}
