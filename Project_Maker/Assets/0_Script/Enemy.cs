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
    float attackPower;
    float moveSpeed;
    int rewardExp;
    int rewardGold;

    bool isAttack;
    float attackTime;

    private void OnEnable()
    {
        target = PlayerControl.Instance.Player;
        isAttack = false;
    }
    public void Initialize(int _monsterID)
    {
        MonsterSheetData data = Sdata.GetMonsterData(_monsterID);

        MaxHp = (float)data.HP_I;
        attackPower = data.Attack_L / 1000f;
        moveSpeed = data.Speed_L / 1000f;
        rewardExp = data.Rewardexp_I;
        rewardGold = data.Reward_I;

        NowHP = MaxHp;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isAttack = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAttack = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Attack();
    }

    void Attack()
    {
        attackTime += Time.fixedDeltaTime;
        if (isAttack && 1 < attackTime)
        {
            target.Damaged(attackPower);
            attackTime = 0;
        }
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
        StageControl.Instance.playerStageData.Exp += rewardExp;
        GameManager.Instance.Pdata.AddGold(rewardGold);
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
