using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseScene : MonoBehaviour
{
    public Define.SceneType SceneType { get; set; } = Define.SceneType.Default;

    public Camera Camera { get; private set; }

    public virtual void init()
    {
        Managers.Scene.CurrentScene = this;
        Object obj = Object.FindObjectOfType<EventSystem>();
        if (obj == null)
            Managers.Resource.Instantiate("UI/@EventSystem");
        Camera = Managers.Resource.Instantiate("Etc/@MainCamera").GetComponent<Camera>();
    }

    public virtual void Clear()
    {
        
    }

    void Awake()
    {
        init();
    }
}
