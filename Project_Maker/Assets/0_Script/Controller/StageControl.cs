using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : ControlBase<StageControl>
{
    public PlayerStageData playerStageData;

    Coroutine Cor_Upgrade;
    public float UpgradeCount;

    public void Initialize()
    {
        playerStageData = new PlayerStageData();
        UIControl.Instance.RefreshStageUI();
        UpgradeCount = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
        }
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
