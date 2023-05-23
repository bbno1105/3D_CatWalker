using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : ControlBase<PlayerControl>
{
    [SerializeField] Player player;
    [SerializeField] JoyStick joyStick;

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

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (joyStick.InputJoyStick()) player.Move(MoveDirection, MoveRate);
    }
}
