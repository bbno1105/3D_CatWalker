using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : ControlBase<UIControl>
{
    // 몬스터
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
