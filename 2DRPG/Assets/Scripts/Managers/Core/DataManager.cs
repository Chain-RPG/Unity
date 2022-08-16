using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public void init()
    {

    }

    public void Clear()
    {

    }
    
    T GetJson<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }
}
