using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : ControlBase<PlayerControl>
{
    [SerializeField] Transform player;

    public Vector2 MoveDirection;
    public float MoveRate;

    protected override void Open(PlayerData _pData)
    {
        base.Open(_pData);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
