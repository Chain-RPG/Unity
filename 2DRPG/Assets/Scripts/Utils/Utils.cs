using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Utils
{
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = true) where T : Component
    {
        if (recursive)
        {
            T[] t = go.transform.GetComponentsInChildren<T>();
            foreach (T t2 in t)
            {
                if(!string.IsNullOrEmpty(name) && name.Equals(t2.gameObject.name))
                    return t2;
            }
        }
        else
        {
            int count = go.transform.childCount;
            for(int i = 0; i < count; i++)
            {
                T t = go.transform.GetChild(i).GetComponent <T>();
                if (t != null)
                    if (!string.IsNullOrEmpty(name) && name.Equals(t.gameObject.name))
                        return t;
            }
        }
        return null;
    }

    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        if(go == null)
            return null;
        T t = go.GetComponent<T>();
        if (t == null)
            t = go.AddComponent<T>();
        return t;
    }

    public static void AddUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvents type = Define.UIEvents.click)
    {
        if (go == null)
            return;
        UIEvent uiEvent = go.GetOrAddComponent<UIEvent>();
        switch (type)
        {
            case Define.UIEvents.beginDrag:
                uiEvent.beginDragAction = action;
                break;
            case Define.UIEvents.onDrag:
                uiEvent.onDragAction = action;
                break;
            case Define.UIEvents.drop:
                uiEvent.dropAction = action;
                break;
            case Define.UIEvents.click:
                uiEvent.clickAction = action;
                break;
        }
    }
}
