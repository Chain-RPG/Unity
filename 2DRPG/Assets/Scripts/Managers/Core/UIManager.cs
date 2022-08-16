using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int count = 10;
    SceneUI scene;
    public SceneUI CurrentScene { get { return scene; } }
    Stack<PopupUI> popups = new Stack<PopupUI>();

    Transform root;
    public Transform Root
    {
        get
        {
            if(root == null)
            {
                GameObject go = GameObject.Find("@UI_Root");
                if (go == null)
                    go = new GameObject() { name = "@UI_Root" };
                root = go.transform;
            }
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true, int layer = 0)
    {
        Canvas canvas = go.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;
        if (sort)
            canvas.sortingOrder = count++;
        else
            canvas.sortingOrder = layer;
    }

    public void SetCanvasCamera(GameObject go, bool sort = true, int layer = 0)
    {
        Canvas canvas = go.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Managers.Scene.CurrentScene.Camera;
        canvas.overrideSorting = true;
        if (sort)
            canvas.sortingOrder = count++;
        else
            canvas.sortingOrder = layer;
    }

    public T ShowSceneUI<T>(string name = null) where T : SceneUI
    {
        CloseSceneUI();
        if (name == null)
            name = typeof(T).Name;
        if (!name.StartsWith("UI/SceneUI/"))
            name = $"UI/SceneUI/{name}";
        GameObject go = Managers.Resource.Instantiate(name);
        if (go == null)
            return null;
        T t = go.GetOrAddComponent<T>();
        scene = t;
        t.gameObject.SetActive(true);
        t.transform.SetParent(Root);
        return t;
    }

    public T ShowPopupUI<T>(string name = null) where T : PopupUI
    {
        if (name == null)
            name = typeof(T).Name;
        if (!name.StartsWith("UI/PopupUI/"))
            name = $"UI/Popup/{name}";
        GameObject go = Managers.Resource.Instantiate(name);
        if (go == null)
            return null;
        T t = go.GetOrAddComponent<T>();
        popups.Push(t);
        t.gameObject.SetActive(true);
        t.transform.SetParent(Root);
        return t;
    }

    public T ShowEctUI<T>(GameObject parent, string name = null) where T : EtcUI
    {
        if (name == null)
            name = typeof(T).Name;
        if (!name.StartsWith("UI/EtcUI/"))
            name = $"UI/EtcUI/{name}";
        GameObject go = Managers.Resource.Instantiate(name);
        if (go == null)
            return null;
        T t = go.GetOrAddComponent<T>();
        t.gameObject.SetActive(true);
        t.transform.SetParent(parent.transform);
        return t;
    }

    public void CloseSceneUI()
    {
        if (CurrentScene != null)
        {
            CurrentScene.Clear();
            scene = null;
        }
    }

    public void ClosePopupUI()
    {
        if (popups.Count == 0)
            return;
        PopupUI popup = popups.Pop();
        Object.Destroy(popup);
    }

    public void ClosePopupUI(PopupUI popup)
    {
        if (popups.Peek() == popup)
            ClosePopupUI();
    }

    public void ClosePopupUIAll()
    {
        while(popups.Count != 0)
            ClosePopupUI();
    }

    public void Clear()
    {
        ClosePopupUIAll();
        scene = null;
    }
}
