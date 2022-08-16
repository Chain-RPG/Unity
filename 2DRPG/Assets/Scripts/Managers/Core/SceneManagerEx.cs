using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene { get; set; }

    public void LoadScene(Define.SceneType type = Define.SceneType.Default)
    {
        Managers.Manager.Clear();
        SceneManager.LoadScene(GetSceneType(type));
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }

    string GetSceneType(Define.SceneType type)
    {
        return Enum.GetName(typeof(Define.SceneType), type);
    }
}
