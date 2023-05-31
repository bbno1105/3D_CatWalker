using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public PlayerData()
    {
        Level = 1;
        ATTDMG = 135;
        ATTSPD = 10;
        MoveSPD = 10;

        ShotSpeed = 10;
        BallLifeTime = 1;
    }

    public int Level;
    public float ATTDMG;
    public float ATTSPD;
    public float MoveSPD;

    // Ball
    public float ShotSpeed; // ÃÑ¾Ë ¼Óµµ
    public float BallLifeTime; // ÃÑ ¼Óµµ
}