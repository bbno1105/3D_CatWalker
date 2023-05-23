using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public PlayerData()
    {
        Level = 1;
        ATTDMG = 10;
        ATTSPD = 10;
        MoveSPD = 10;
    }

    public int Level;
    public int ATTDMG;
    public int ATTSPD;
    public int MoveSPD;
}
