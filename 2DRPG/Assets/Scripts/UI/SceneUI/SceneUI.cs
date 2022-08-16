using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUI : BaseUI
{
    public virtual void init()
    {
        Managers.UI.SetCanvas(gameObject, false);
    }

    public virtual void Clear()
    {
        Managers.Resource.Destroy(gameObject);
    }

    void Start()
    {
        init(); 
    }
}
