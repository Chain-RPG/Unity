using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using static Define;

public class PacketController
{
    static PacketController controller;
    public static PacketController Controller { get 
        {
            if (controller == null)
                controller = new PacketController();
            return controller;
        } 
    }

    Dictionary<NetworkMethod, Action<object, MessageEventArgs>> checkPacket = new Dictionary<NetworkMethod, Action<object, MessageEventArgs>>();
    Dictionary<NetworkMethod, Action<object, ReceivePacket>> handlers = new Dictionary<NetworkMethod, Action<object, ReceivePacket>>();

    PacketController()
    {
        init();
    }

    void init()
    {
        checkPacket.Add(NetworkMethod.TEST, MakePacket<Re_Test>);
        handlers.Add(NetworkMethod.TEST, PacketHandler.Test_Handler);

        checkPacket.Add(NetworkMethod.ERROR, MakePacket<Re_Error>);
        handlers.Add(NetworkMethod.ERROR, PacketHandler.Error_Handler);

        checkPacket.Add(NetworkMethod.SIGN_UP, MakePacket<Re_Sign_Up>);
        handlers.Add(NetworkMethod.SIGN_UP, PacketHandler.Sign_Up_Handler);

        checkPacket.Add(NetworkMethod.SIGN_IN, MakePacket<Re_Sign_In>);
        handlers.Add(NetworkMethod.SIGN_IN, PacketHandler.Sign_In_Handler);

        checkPacket.Add(NetworkMethod.CREATE_PLAYER, MakePacket<Re_Create_Player>);
        handlers.Add(NetworkMethod.CREATE_PLAYER, PacketHandler.Create_Player_Handler);

        checkPacket.Add(NetworkMethod.SELECT_PLAYER, MakePacket<Re_Select_Player>);
        handlers.Add(NetworkMethod.SELECT_PLAYER, PacketHandler.Select_Player_Handler);
    }

    public void CheckPacket(object sender, MessageEventArgs e)
    {
        ReceivePacket packet = JsonUtility.FromJson<ReceivePacket>(e.Data);
        if (packet.status != 1)
        {
            Debug.Log(packet.status);
        }
        NetworkMethod method = Enum.Parse<NetworkMethod>(packet.method);
        Action<object, MessageEventArgs> action = null;
        if (checkPacket.TryGetValue(method, out action))
            action.Invoke(sender, e);
    }

    void MakePacket<T>(object sender, MessageEventArgs e) where T : ReceivePacket
    {
        T packet = JsonUtility.FromJson<T>(e.Data);
        NetworkMethod method = Enum.Parse<NetworkMethod>(packet.method);
        Action<object, ReceivePacket> action = null;
        if (handlers.TryGetValue(method, out action))
            action.Invoke(sender, packet);
    }
}
