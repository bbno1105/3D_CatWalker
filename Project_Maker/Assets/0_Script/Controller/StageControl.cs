using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : ControlBase<StageControl>
{
    public enum STATE
    {
        NONE = 0,
        CAMP,
        FIELD,
    }
    STATE state;
    public STATE State { get { return state; } }

    public PlayerStageData playerStageData;

    Coroutine Cor_Upgrade;
    public float UpgradeCount;

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
        // test
        ChangeState(STATE.FIELD);
    }

    public void ChangeState(STATE _state)
    {
        state = _state;
        switch (state)
        {
            case STATE.NONE:
                break;
            case STATE.CAMP:
                {
                    PlayerControl.Instance.ChangeState(PlayerControl.STATE.NONE);
                }
                break;
            case STATE.FIELD:
                {
                    PlayerControl.Instance.ChangeState(PlayerControl.STATE.PLAY);

                    // 새로운 필드 시작
                    UpgradeCount = 0;

                    playerStageData = new PlayerStageData();

                    UIControl.Instance.RefreshStageUI();
                    UIControl.Instance.RefreshStagePlayerUI();
                }
                break;
            default:
                break;
        }
    }

    public void StartStage()
    {
        ChangeState(STATE.FIELD);
    }

    // FIELD
    public void Upgrade()
    {
        if (Cor_Upgrade != null) StopCoroutine(Cor_Upgrade);
        Cor_Upgrade = StartCoroutine(UpgradeCoroutine());
    }

    IEnumerator UpgradeCoroutine()
    {
        while(0 < UpgradeCount)
        {
            UIControl.Instance.ActiveUpgrade(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
