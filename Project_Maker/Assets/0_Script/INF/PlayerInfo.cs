using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public PlayerData()
    {
        level = 1;

        hp = 10;
        attDMG = 10;
        attSPD = 1;
        moveSPD = 10;
        
        shotSpeed = 50;
        ballLifeTime = 1;
    }

    int gold;
    public int Gold { get { return gold; } }

    int level;
    public int Level { get { return level; } }

    int hp;
    public int HP { get { return hp; } }

    float attDMG;
    public float ATTDMG { get { return attDMG; } }

    float attSPD;
    public float ATTSPD { get { return attSPD; } }

    float moveSPD;
    public float MoveSPD { get { return moveSPD; } }

    // Ball
    float shotSpeed; // ÃÑ¾Ë ¼Óµµ
    public float ShotSpeed { get { return shotSpeed; } }

    float ballLifeTime; // ÃÑ ¼Óµµ
    public float BallLifeTime { get { return ballLifeTime; } }

    public void AddGold(int value)
    {
        gold += value;
        UIControl.Instance.RefreshGold(Gold);
    }
}