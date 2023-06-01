using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sdata : SingletonBehabiour<Sdata>
{
    [SerializeField] Envi EnviData;
    public static EnviData[] Envis { get { return Instance.EnviData.dataArray; } }

    public static EnviData GetEnviData(string _id)
    {
        for (int i = 0; i < Envis.Length; i++)
            if (Envis[i].ID_S == _id)
                return Envis[i];
        return null;
    }

    [SerializeField] Exp ExpData;
    public static ExpData[] Exps { get { return Instance.ExpData.dataArray; } }

    public static ExpData GetExpData(int _id)
    {
        for (int i = 0; i < Exps.Length; i++)
            if (Exps[i].ID_I == _id)
                return Exps[i];
        return null;
    }

    [SerializeField] Upgrade UpgradeData;
    public static UpgradeData[] Upgrades { get { return Instance.UpgradeData.dataArray; } }

    public static UpgradeData GetUpgradeData(int _id)
    {
        for (int i = 0; i < Upgrades.Length; i++)
            if (Upgrades[i].ID_I == _id)
                return Upgrades[i];
        return null;
    }

}
