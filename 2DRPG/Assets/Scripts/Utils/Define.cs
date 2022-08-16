using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum UIEvents
    {
        beginDrag,
        onDrag,
        drop,
        click
    }

    public enum SceneType
    {
        Default,
        LogIn,
        Game,
    }

    public enum NetworkMethod
    {
        TEST,
        ERROR,
        SIGN_UP,
        SIGN_IN,
        CREATE_PLAYER,
        SELECT_PLAYER,
        CHAT,
        GET_INVENTORY,
        GET_STAT,
        ADD_STAT
    }

    public enum StatType
    {
        MAXHP,
        HP,
        MAXMN,
        MN,
        ATK,
        MATK,
        ATS,
        CRI,
        CRID,
        DEF,
        MDEF,
        BRE,
        MBRE,
        DRA,
        MDRA,
        SPD,
        CHA
    }

    public enum EntityType
    {
        PLAYER,
        MONSTER,
        BOSS
    }
}
