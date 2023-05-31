using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public EnemyUI HPUI;
    [SerializeField] Transform enemyModel;
    Player target;

    // ½ºÅÝ
    public float NowHP;
    public float MaxHp;
    float moveSpeed;

    private void OnEnable()
    {
        moveSpeed = 1;
        MaxHp = 10000;

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

        UIControl.Instance.ActiveDamageUI(HPUI.transform.position, _damage);
    }

    void Die()
    {
        gameObject.SetActive(false);
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
