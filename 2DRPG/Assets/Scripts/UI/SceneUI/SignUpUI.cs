using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Mail;
using System;

public class SignUpUI : SceneUI
{
    enum Images
    {
        Image
    }

    enum Texts
    {
        Text
    }

    enum InputFields
    {
        InputField
    }

    public override void init()
    {
        base.init();
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<TMP_InputField>(typeof(InputFields));
        Get<Image>(0).gameObject.AddUIEvent(e => {
            string email = Get<TMP_InputField>((int)InputFields.InputField).text;
            if (CheakEmail(email))
            {
                Send_Sign_Up signUp = new Send_Sign_Up()
                {
                    email = email
                };
                Managers.Network.Send(signUp, Define.NetworkMethod.SIGN_UP);
            }
            else
            {
                this.Get<TMP_InputField>((int)InputFields.InputField).text = "Wrong Format!";
            }
        }, Define.UIEvents.click);
    }

    static bool CheakEmail(string email)
    {
        try
        {
            MailAddress m = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public override void Clear()
    {
        base.Clear();
    }
}
