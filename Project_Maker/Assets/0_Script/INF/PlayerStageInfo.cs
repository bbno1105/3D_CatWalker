using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStageData
{
    public PlayerStageData()
    {
        level = 0;
        exp = 0;
    }

    
    int level;
    public int Level { get { return level; } set { SetLevel(value); } }

    int exp;
    public int Exp
    {
        get { return exp; }
        set
        {
            exp = value;
            SetExp();
            UIControl.Instance.RefreshStageUI();
        }
    }

    void SetLevel(int value)
    {
        if (value < 10)
        {
            level = value;
        }
        // MaxLevel
    }

    void SetExp()
    {
        int expData = Sdata.GetExpData(Level).EXP_I;

        if (expData <= exp)
        {
            StageControl.Instance.UpgradeCount++;
            SetLevel(Level + 1);
            exp -= expData;
            SetExp();
        }
        StageControl.Instance.Upgrade();
    }
}

