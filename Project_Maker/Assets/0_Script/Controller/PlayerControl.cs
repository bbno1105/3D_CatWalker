using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : ControlBase<PlayerControl>
{
    [SerializeField] Transform player;
    Transform playerModel;
    Animator anicon;

    public Vector2 MoveDirection;
    public float MoveRate;

    protected override void Awake()
    {
        base.Awake();

        playerModel = player.GetChild(0);
        anicon = playerModel.GetComponent<Animator>();
    }
    protected override void Open(PlayerData _pData)
    {
        base.Open(_pData);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        anicon.SetFloat("MoveBlend", MoveRate);
        playerModel.forward = new Vector3(MoveDirection.x, 0, MoveDirection.y);
        player.position += playerModel.forward * MoveRate * Sdata.GetEnviData("PlayerSpeed").Longvalue_L * Time.deltaTime;
    }
}
