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
            float x = 0 < Random.Range(0, 2) ? Random.Range(0, 1f) : Random.Range(-1f, 0);
            float y = 0 < Random.Range(0, 2) ? -1 : 2;

            Vector3 createPos = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 1));
            createPos = new Vector3(createPos.x, playerPos.y, createPos.z);
            EnemyControl.Instance.ActiveEnemy(createPos);
        }
    }
}
