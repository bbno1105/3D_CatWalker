using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sdata : SingletonBehabiour<Sdata>
{
    [SerializeField] Envi EnviData;
    public static EnviData[] Envis { get { return Instance.EnviData.dataArray; } } //MonserS로 표기한 이유는?

    public static EnviData GetEnviData(string _id)
    {
        for (int i = 0; i < Envis.Length; i++)
            if (Envis[i].ID_S == _id)
                return Envis[i];
        return null;
    }
}
