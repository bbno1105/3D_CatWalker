using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int StageNum;

    public int MonsterCount;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            CreateMonster();
        }
    }

    void CreateMonster()
    {
        Vector3 playerPos = PlayerControl.Instance.Player.transform.position;

        for (int i = 0; i < MonsterCount; i++)
        {
            float x = 0 < Random.Range(0, 1) ? Random.Range(0, 1f) : Random.Range(-1f, 0);
            float y = 0 < Random.Range(0, 1) ? -1 : 1;

            Vector3 createPos = new Vector3(playerPos.x + 5 * x, playerPos.y, playerPos.z * 15 * y);
            EnemyControl.Instance.ActiveEnemy(createPos);
        }
    }
}
