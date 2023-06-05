using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : ControlBase<UIControl>
{
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

    }

    // Gold UI
    [Header("Gold")]
    [SerializeField] TextMeshProUGUI Txt_Gold;
    public void RefreshGold(int _gold)
    {
        Txt_Gold.text = _gold.ToString();
    }

    // StageData UI
    [Header("StageData")]
    [SerializeField] TextMeshProUGUI Txt_level;
    [SerializeField] Transform UpgradeUI;

    // StageData UI
    [Header("StagePlayerData")]
    [SerializeField] Slider Slider_PlayerHP;
    [SerializeField] TextMeshProUGUI Txt_exp;
    [SerializeField] Slider Slider_exp;

    public void RefreshStagePlayerUI()
    {
        Player player = PlayerControl.Instance.Player;
        Slider_PlayerHP.value = player.NowHP / player.MaxHP;
    }

    public void RefreshStageUI()
    {
        PlayerStageData PData_S = StageControl.Instance.playerStageData;

        Txt_level.text = PData_S.Level.ToString();
        Txt_exp.text = PData_S.Exp.ToString();
        Slider_exp.value = (float)PData_S.Exp / Sdata.GetExpData(PData_S.Level).EXP_I;
    }

    public void ActiveUpgrade(bool _isActive)
    {
        UpgradeUI.gameObject.SetActive(_isActive);

        if(_isActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            StageControl.Instance.UpgradeCount--;
        }
    }

    // 몬스터
    [Header("Monster")]
    [SerializeField] EnemyUI EnemyUIPrefab;
    [SerializeField] Transform EnemyUIParent;
    [HideInInspector] public Stack<EnemyUI> EnemyUIPool = new Stack<EnemyUI>();

    public EnemyUI ActiveEnemyUI(Enemy _targetEnemy)
    {
        if (EnemyUIPool.Count == 0) CreateEnemyUI(5);

        EnemyUI newUI = EnemyUIPool.Pop();
        newUI.target = _targetEnemy;
        newUI.gameObject.SetActive(true);
        return newUI;
    }

    void CreateEnemyUI(int _count)
    {
        for(int i = 0; i < _count; i++)
        {
            EnemyUI newUI = GameObject.Instantiate(EnemyUIPrefab, EnemyUIParent);
            newUI.gameObject.SetActive(false);
        }
    }

    // 데미지
    [Header("Damage")]
    [SerializeField] Damage DamageUIPrefab;
    [SerializeField] Transform DamageUIParent;
    [HideInInspector] public Stack<Damage> DamagePool = new Stack<Damage>();

    public void ActiveDamageUI(Vector3 _ActivePos, float _damage)
    {
        if (DamagePool.Count == 0) CreateDamageUI(10);

        Damage newUI = DamagePool.Pop();

        newUI.TxtDamage.text = ((int)_damage).ToString();
        newUI.ActivePos = _ActivePos;

        newUI.gameObject.SetActive(true);
    }

    void CreateDamageUI(int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            Damage newUI = GameObject.Instantiate(DamageUIPrefab, DamageUIParent);
            newUI.gameObject.SetActive(false);
        }
    }
}
