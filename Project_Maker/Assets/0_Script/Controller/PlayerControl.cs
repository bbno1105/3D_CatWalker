using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : ControlBase<PlayerControl>
{
    public enum STATE
    {
        NONE = 0,
        PLAY,
        DIE,
    }
    STATE state;
    public STATE State { get { return state; } } 

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

    public override void Open(PlayerData _pData)
    {
        base.Open(_pData);
    }

    public override void Initialize()
    {
        Player.Initialize(PData.HP);
    }

    void Update()
    {
        switch (State)
        {
            case STATE.NONE:
                break;
            case STATE.PLAY:
                {
                    Search();
                    Move();
                    Attack();
                }
                break;
            case STATE.DIE:
                break;
            default:
                break;
        }
    }

    public void ChangeState(STATE _state)
    {
        state = _state;
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
        time += PData.ATTSPD * Time.deltaTime;

        if (Player.SearchArea.IsTargetOn)
        {
            if(1 < time)
            {
                Player.Attack(PData.ATTSPD);
                time = 0;
            }
        }
        else if (target)
        {
            target = null;
        }
    }
}
