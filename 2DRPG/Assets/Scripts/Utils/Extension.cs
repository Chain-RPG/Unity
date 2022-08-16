using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static T FindChild<T>(this GameObject go, string name = null, bool recursive = true) where T : Component
    {
        return Utils.FindChild<T>(go, name, recursive);
    }

    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        return Utils.GetOrAddComponent<T>(go);
    }

    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvents type = Define.UIEvents.click)
    {
        Utils.AddUIEvent(go, action, type);
    }
}
