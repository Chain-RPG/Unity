using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : SceneUI
{
    public List<Player> players;
    public List<CharacterSelectButtonUI> buttonUIs { get; private set; }

    enum Images
    {
        CharacterPlusImage
    }

    enum GameObjects
    {
        Contents
    }

    public override void init()
    {
        Managers.UI.SetCanvasCamera(gameObject, false);
        buttonUIs = new List<CharacterSelectButtonUI>();
        Bind<Transform>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
        GameObject content = Get<Transform>((int)GameObjects.Contents).gameObject;
        foreach (Player player in players)
        {
            CharacterSelectButtonUI b = Managers.UI.ShowEctUI<CharacterSelectButtonUI>(content);
            b.Setting();
            b.SetButton(player);
            buttonUIs.Add(b);
        }
        Get<Image>((int)Images.CharacterPlusImage).gameObject.AddUIEvent(p =>
        {
            
        });
    }

    public override void Clear()
    {
        base.Clear();
    }
}
