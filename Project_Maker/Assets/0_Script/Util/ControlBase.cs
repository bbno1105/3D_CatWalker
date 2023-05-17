using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBase<T> : SingletonBehabiour<T> where T :  ControlBase<T>
{
    protected bool IsOpen = false;
    protected PlayerData PData;
    protected virtual void Open(PlayerData _pData)
    {
        PData = _pData;
        IsOpen = true; 
    }
}
