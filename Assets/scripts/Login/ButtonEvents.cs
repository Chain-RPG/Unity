using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleSocket;
using System.Net.Sockets;

public class Msg
{
    public string email;
}

public class ButtonEvents : MonoBehaviour
{
    public TMP_InputField textInput;
    private Socket socket;
    SimpleSocketClass simpleSocket;
    public void confirm()
    {
        string json = makeString(textInput.text);
        simpleSocket = new SimpleSocketClass("158.247.226.141", 100);
        Debug.Log(textInput.text);
        Debug.Log(makeString(textInput.text));
        simpleSocket.send(makeString(textInput.text));
        Debug.Log(simpleSocket.read());
    }

    public string makeJson(string input)
    {
        var json = new Msg();
        json.email = input;
        return JsonUtility.ToJson(json);
    }

    public string makeString(string input)
    {
        return "SIGN_UP-" + makeJson(input);
    }

}
