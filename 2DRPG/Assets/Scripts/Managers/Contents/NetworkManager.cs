using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using WebSocketSharp;
using static Define;

public class NetworkManager
{
    string path = "ws://namsic.iptime.org";
    int port = 8080;

    private WebSocket Socket;

    public int UserId { get; set; }

    public void init()
    {
        try
        {
            Socket = new WebSocket(path + ":" + port);
            Socket.OnMessage += (sender, e) => {
                Debug.Log(e.Data);
                PacketController.Controller.CheckPacket(sender, e);
            };
            Socket.Connect();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void Send(SendPacket packet, NetworkMethod method)
    {
        try
        {
            switch (method)
            {
                case NetworkMethod.TEST:
                    Send_Test test = packet as Send_Test;
                    Socket.Send($"TEST-{{\"message\":\"{test.message}\"}}");
                    break;
                case NetworkMethod.SIGN_UP:
                    Send_Sign_Up signUp = packet as Send_Sign_Up;
                    Socket.Send($"SIGN_UP-{{\"email\":\"{signUp.email}\"}}");
                    break;
                case NetworkMethod.SIGN_IN:
                    Send_Sign_In signIn = packet as Send_Sign_In;
                    Socket.Send($"SIGN_IN-{{\"email\":\"{signIn.email}\"}}");
                    break;
                case NetworkMethod.CREATE_PLAYER:
                    Send_Create_Player createPlayer = packet as Send_Create_Player;
                    Socket.Send($"CREATE_PLAYER-{{\"name\":\"{createPlayer.name}\"}}");
                    break;
                case NetworkMethod.SELECT_PLAYER:
                    Send_Select_Player selectPlayer = packet as Send_Select_Player;
                    Socket.Send($"SELECT_PLAYER-{{\"playerId\":\"{selectPlayer.playerId}\"}}");
                    break;
                case NetworkMethod.CHAT:
                    break;
                case NetworkMethod.GET_INVENTORY:
                    break;
                case NetworkMethod.GET_STAT:
                    break;
                case NetworkMethod.ADD_STAT:
                    break;
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }

    public void Clear()
    {
        try
        {
            Socket.Close();
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }
}
