using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPacket
{
    
}

public class Send_Test : SendPacket
{
    public string message;
}

public class Send_Sign_Up : SendPacket
{
    public string email;
}

public class Send_Sign_In : SendPacket
{
    public string email;
}

public class Send_Create_Player : SendPacket
{
    public string name;
}

public class Send_Select_Player : SendPacket
{
    public long playerId;
}

public class Send_Chat : SendPacket
{
    public string chatType;
    public string message;
}

public class Send_Get_Inventory : SendPacket
{

}

public class Send_Get_Stat : SendPacket
{

}

public class Send_Add_Stat : SendPacket
{

}