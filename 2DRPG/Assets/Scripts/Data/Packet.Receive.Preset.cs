using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivePacket
{
    public string method;
    public int status;
}

[Serializable]
public class Map
{
    public List<Field_Entity> fieldEntityList;
    public bool isField;
    public string name;
}

[Serializable]
public class Entity
{
    public long id;
    public string entityType;
    public string name;
    public int lv;
    public int maxHp;
    public int hp;
    public int maxMn;
    public int mn;
}

[Serializable]
public class Player : Entity
{
    public string image;
    public string mapName;
}

[Serializable]
public class Field_Entity : Entity
{
    public int fieldX;
    public int fieldY;
}

[Serializable]
public class Town_Player : Player
{
    public bool hasMarketSoldObject;
    public bool hasRemainSp;
    public bool hasUncheckedAcceptedFriendRequest;
    public List<long> hasUncheckedEquipIdList;
    public bool hasUncheckedEvent;
    public bool hasUncheckedFriendRequest;
    public List<Item> hasUncheckedItemIdList;
    public bool isCompletedTutorial;
}

[Serializable]
public class Item
{
    public long id;
    public int type;
}

public class Re_Test : ReceivePacket
{
    public string message;
}

public class Re_Error : ReceivePacket
{
    public string message;
}

public class Re_Sign_Up : ReceivePacket
{
    public int userId;
    public List<Player> playerList = new List<Player>();
}

public class Re_Sign_In : ReceivePacket
{
    public int userId;
    public List<Player> playerList = new List<Player>();
}

public class Re_Create_Player : ReceivePacket
{
    public Map gameMap;
    public Town_Player player;
}


public class Re_Select_Player : ReceivePacket
{
    public Map gameMap;
    public Town_Player player;
}

public class Re_Chat : ReceivePacket
{
    public string chatType;
    public string message;
    public string sender;
    public string title;
}

public class Re_Get_Inventory : ReceivePacket
{

}

public class Re_Get_Stat : ReceivePacket
{

}

public class Re_Add_Stat : ReceivePacket
{

}