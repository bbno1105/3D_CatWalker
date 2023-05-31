using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : ControlBase<EnemyControl>
{
    [SerializeField] Enemy EnemyPrefab;
    [SerializeField] Transform EnemyPoolParent;
    public Stack<Enemy> EnemyPool = new Stack<Enemy>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            ActiveEnemy(Vector3.zero);
        }
    }

    public void ActiveEnemy(Vector3 _activePosition)
    {
        if (EnemyPool.Count == 0) CreateEnemy(10);

        Enemy newEmeny = EnemyPool.Pop();
        newEmeny.transform.position = _activePosition;
        newEmeny.gameObject.SetActive(true);
    }

    void CreateEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Enemy newEmeny = GameObject.Instantiate(EnemyPrefab, EnemyPoolParent);
            newEmeny.gameObject.SetActive(false);
        }
    }
}
