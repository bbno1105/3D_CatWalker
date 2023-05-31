using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator anicon;
    [SerializeField] Transform ballCreatePos;

    public Transform playerModel;
    public SearchEnemy SearchArea;

    public void Attack(float _attackSpeed)
    {
        if (SearchArea.IsTargetOn)
        {
            playerModel.LookAt(PlayerControl.Instance.target.transform);
        }

        BallControl.Instance.ShotBall(ballCreatePos.position, playerModel.forward);
        anicon.SetFloat("AttackSpeed", _attackSpeed);
        anicon.SetTrigger("Attack");
    }

    public void Move(Vector2 MoveDirection, float MoveRate)
    {
        Vector3 moveVector = new Vector3(MoveDirection.x, 0, MoveDirection.y);

        if (!SearchArea.IsTargetOn)
        {
            playerModel.forward = moveVector;
        }

        transform.position += moveVector * MoveRate * Sdata.GetEnviData("PlayerSpeed").Longvalue_L * Time.deltaTime;
        anicon.SetFloat("MoveBlend", MoveRate);
    }
}
