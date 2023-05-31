using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : ControlBase<PlayerControl>
{
    public Player Player;

    [SerializeField] JoyStick joyStick;

    // Move
    public Vector2 MoveDirection;
    public float MoveRate;

    // Attack
    float time;
    public Enemy target;

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
        Search();
        Move();
        Attack();
    }

    void Search()
    {
        Player.SearchArea.RefreshTarget();
    }

    public void Move()
    {
        if (joyStick.InputJoyStick()) Player.Move(MoveDirection, MoveRate);
    }

    public void Attack()
    {
        if (Player.SearchArea.IsTargetOn)
        {
            time += PData.ATTSPD * Time.deltaTime;
            if(1 < time)
            {
                Player.Attack(PData.ATTSPD);
                time = 0;
            }
        }
        else if (target)
        {
            target = null;
            time = 0;
        }
    }
}
