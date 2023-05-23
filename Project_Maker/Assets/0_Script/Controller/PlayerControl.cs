using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : ControlBase<PlayerControl>
{
    [SerializeField] Player player;

    public Vector2 MoveDirection;
    public float MoveRate;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Open(PlayerData _pData)
    {
        base.Open(_pData);
    }

    public void Move()
    {
        player.Move(MoveDirection, MoveRate);
    }

}
