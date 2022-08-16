using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignInUI : SceneUI
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
                Send_Sign_In signIn = new Send_Sign_In()
                {
                    email = email
                };
                Managers.Network.Send(signIn, Define.NetworkMethod.SIGN_IN);
            }
            else
            {
                Get<TMP_InputField>((int)InputFields.InputField).text = "Wrong Format!";
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
