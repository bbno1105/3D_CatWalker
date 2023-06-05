using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : ControlBase<StageControl>
{
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
        UpgradeCount = 0;

        playerStageData = new PlayerStageData();

        UIControl.Instance.RefreshStageUI();
        UIControl.Instance.RefreshStagePlayerUI();
    }

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
