using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInScene : BaseScene
{
    public WaveController Wave { get; private set; }
    public override void init()
    {
        base.init();
        SceneType = Define.SceneType.LogIn;
        Wave = gameObject.GetOrAddComponent<WaveController>();
        Managers.UI.ShowSceneUI<GameStartUI>();
    }

    public override void Clear()
    {
        base.Clear();
    }
}
