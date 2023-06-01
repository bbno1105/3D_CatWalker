using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public EnemyUI HPUI;
    [SerializeField] Transform enemyModel;
    Player target;

    // 스텟
    public float NowHP;
    public float MaxHp;
    float moveSpeed;

    private void OnEnable()
    {
        moveSpeed = 1;
        MaxHp = 1000;

        target = PlayerControl.Instance.Player;
        NowHP = MaxHp;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        enemyModel.LookAt(target.transform);
        transform.position += enemyModel.forward * moveSpeed * Time.fixedDeltaTime;
    }

    public void HitDamage(float _damage)
    {
        NowHP -= _damage;
        
        if(NowHP <= 0)
        {
            NowHP = 0;
            Die();
        }

        if(HPUI == null)
        {
            HPUI = UIControl.Instance.ActiveEnemyUI(this);
        }
        else
        {
            HPUI.Initialize();
        }

        // 데미지 UI
        UIControl.Instance.ActiveDamageUI(transform.position, _damage);
    }

    void Die()
    {
        gameObject.SetActive(false);

        // 임시
        StageControl.Instance.playerStageData.Exp += 500;
        GameManager.Instance.Pdata.AddGold(100);
    }

    void OnDisable()
    {
        EnemyControl.Instance.EnemyPool.Push(this);

        SearchEnemy search = PlayerControl.Instance.Player.SearchArea;
        if (search.targets.Contains(this))
        {
            search.targets.Remove(this);
            search.IsTargetOn = 0 < search.targets.Count ? true : false;
        }
    }
}
