using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sdata : SingletonBehabiour<Sdata>
{
    [SerializeField] EnviSheet EnviData;
    public static EnviSheetData[] Envis { get { return Instance.EnviData.dataArray; } }

    public static EnviSheetData GetEnviData(string _id)
    {
        for (int i = 0; i < Envis.Length; i++)
            if (Envis[i].ID_S == _id)
                return Envis[i];
        return null;
    }

    [SerializeField] ExpSheet ExpData;
    public static ExpSheetData[] Exps { get { return Instance.ExpData.dataArray; } }

    public static ExpSheetData GetExpData(int _id)
    {
        for (int i = 0; i < Exps.Length; i++)
            if (Exps[i].ID_I == _id)
                return Exps[i];
        return null;
    }

    [SerializeField] UpgradeSheet UpgradeData;
    public static UpgradeSheetData[] Upgrades { get { return Instance.UpgradeData.dataArray; } }

    public static UpgradeSheetData GetUpgradeData(int _id)
    {
        for (int i = 0; i < Upgrades.Length; i++)
            if (Upgrades[i].ID_I == _id)
                return Upgrades[i];
        return null;
    }

    [SerializeField] MonsterSheet MonsterData;
    public static MonsterSheetData[] Monsters { get { return Instance.MonsterData.dataArray; } }

    public static MonsterSheetData GetMonsterData(int _id)
    {
        for (int i = 0; i < Monsters.Length; i++)
            if (Monsters[i].ID_I == _id)
                return Monsters[i];
        return null;
    }

}
