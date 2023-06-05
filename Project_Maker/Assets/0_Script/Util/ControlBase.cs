using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBase<T> : SingletonBehabiour<T> where T :  ControlBase<T>
{
    protected bool IsOpen = false;
    protected PlayerData PData;

    protected virtual void Start()
    {
        if (!IsOpen)
        {
            Open(GameManager.Instance.Pdata);
            IsOpen = true;
        }
    }

    public virtual void Open(PlayerData _pData)
    {
        PData = _pData;
        IsOpen = true;
        Initialize();
    }

    public virtual void Initialize()
    {

    }
}
