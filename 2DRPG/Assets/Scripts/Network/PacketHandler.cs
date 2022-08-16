using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketHandler
{
    public static void Test_Handler(object sender, ReceivePacket p)
    {
        Re_Test test = p as Re_Test;
        Debug.Log($"method:{test.method} status:{test.status} message:{test.message}");
    }

    public static void Error_Handler(object sender, ReceivePacket p)
    {
        Re_Error test = p as Re_Error;
        Debug.Log($"Error! method:{test.method} status:{test.status} message:{test.message}");
    }

    public static void Sign_Up_Handler(object sender, ReceivePacket p)
    {
        Re_Sign_Up signUp = p as Re_Sign_Up;
        ProcessingQueue.Processor.Push(() =>
        {
            CharacterSelectUI ui = Managers.UI.ShowSceneUI<CharacterSelectUI>();
            Managers.Network.UserId = signUp.userId;
            ui.players = signUp.playerList;
        });
    }

    public static void Sign_In_Handler(object sender, ReceivePacket p)
    {
        Re_Sign_In signIn = p as Re_Sign_In;
        ProcessingQueue.Processor.Push(() =>
        {
            CharacterSelectUI ui = Managers.UI.ShowSceneUI<CharacterSelectUI>();
            Managers.Network.UserId = signIn.userId;
            ui.players = signIn.playerList;
        });
    }

    public static void Create_Player_Handler(object sender, ReceivePacket p)
    {
        Re_Create_Player createPlayer = p as Re_Create_Player;
        ProcessingQueue.Processor.Push(() =>
        {
            
        });
    }

    public static void Select_Player_Handler(object sender, ReceivePacket p)
    {
        Re_Create_Player createPlayer = p as Re_Create_Player;
        ProcessingQueue.Processor.Push(() =>
        {
            
        });
    }
}
