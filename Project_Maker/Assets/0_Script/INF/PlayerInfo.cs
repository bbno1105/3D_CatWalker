using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public PlayerData()
    {
        level = 1;
        attDMG = 500;
        attSPD = 5;
        moveSPD = 10;

        shotSpeed = 10;
        ballLifeTime = 1;
    }

    int gold;
    public int Gold { get { return gold; } }

    public int level;
    public int Level { get { return level; } }

    public float attDMG;
    public float ATTDMG { get { return attDMG; } }

    public float attSPD;
    public float ATTSPD { get { return attSPD; } }

    public float moveSPD;
    public float MoveSPD { get { return moveSPD; } }

    // Ball
    public float shotSpeed; // ÃÑ¾Ë ¼Óµµ
    public float ShotSpeed { get { return shotSpeed; } }

    public float ballLifeTime; // ÃÑ ¼Óµµ
    public float BallLifeTime { get { return ballLifeTime; } }

    public void AddGold(int value)
    {
        gold += value;
        UIControl.Instance.RefreshGold(Gold);
    }
}