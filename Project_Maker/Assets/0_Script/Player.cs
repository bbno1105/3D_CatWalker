using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform playerModel;
    [SerializeField] Animator anicon;

    // [SerializeField] SearchArea ActiveArea;
    [SerializeField] SearchEnemy ThrowArea;

    Coroutine AttackTargetCoroutine;
    Enemy target;

    void Start()
    {
        if (AttackTargetCoroutine != null) StopCoroutine(AttackTargetCoroutine);
        AttackTargetCoroutine = StartCoroutine(AttackTarget());
    }

    IEnumerator AttackTarget()
    {
        while(true)
        {
            if(0 < ThrowArea.targets.Count)
            {
                Attack();
            }
            else if (target)
            {
                target = null;
            }
            yield return new WaitForSecondsRealtime(1);
        }
    }

    public void Attack()
    {
        FindTargetEnemy(ThrowArea.targets);
        playerModel.LookAt(target.transform);
        anicon.SetTrigger("Attack");
    }

    void FindTargetEnemy(List<Enemy> _enemy)
    {
        float minDistance = float.MaxValue;
        foreach(Enemy ememy in _enemy)
        {
            float distance = Vector3.Distance(this.transform.position, ememy.transform.position);
            if (distance < minDistance)
            {
                target = ememy;
                minDistance = distance;
            }
        }
    }

    public void Move(Vector2 MoveDirection, float MoveRate)
    {
        Vector3 moveVector = new Vector3(MoveDirection.x, 0, MoveDirection.y);

        if (target == null) playerModel.forward = moveVector;

        transform.position += moveVector * MoveRate * Sdata.GetEnviData("PlayerSpeed").Longvalue_L * Time.deltaTime;
        anicon.SetFloat("MoveBlend", MoveRate);
    }
}
