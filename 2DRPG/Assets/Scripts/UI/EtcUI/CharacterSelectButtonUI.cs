using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterSelectButtonUI : EtcUI
{
    enum Texts
    {
        AnnotationText
    }

    private Player player;

    public override void Setting()
    {
        base.Setting();
        Bind<TextMeshProUGUI>(typeof(Texts));
        transform.localScale = Vector3.one;
        gameObject.AddUIEvent(p =>
        {
            Send_Select_Player selectPlayer = new Send_Select_Player()
            {
                playerId = player.id
            };
            Managers.Network.Send(selectPlayer, Define.NetworkMethod.SELECT_PLAYER);
        }, Define.UIEvents.click);
    }

    public void SetButton(Player p)
    {
        player = p;
        Get<TextMeshProUGUI>((int)Texts.AnnotationText).text = p.name;
    }
}
