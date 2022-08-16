using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartUI : SceneUI
{
    enum Texts
    {
        SignIn,
        LogIn,
        Setting,
        Exit
    }

    public override void init()
    {
        base.init();
        Bind<TextMeshProUGUI>(typeof(Texts));
        Get<TextMeshProUGUI>((int)Texts.SignIn).gameObject.AddUIEvent(p =>
        {
            Managers.UI.ShowSceneUI<SignUpUI>();
        }, Define.UIEvents.click);
        Get<TextMeshProUGUI>((int)Texts.LogIn).gameObject.AddUIEvent(p =>
        {
            Managers.UI.ShowSceneUI<SignInUI>();
        }, Define.UIEvents.click);
    }

    public override void Clear()
    {
        base.Clear();
    }
}
