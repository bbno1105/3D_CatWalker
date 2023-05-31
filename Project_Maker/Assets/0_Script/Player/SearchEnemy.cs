using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemy : MonoBehaviour
{
    public List<Enemy> targets = new List<Enemy>();
    public bool IsTargetOn;

    public void RefreshTarget()
    {
        if (IsTargetOn)
        {
            float minDistance = float.MaxValue;
            foreach (Enemy ememy in targets)
            {
                float distance = Vector3.Distance(this.transform.position, ememy.transform.position);
                if (distance < minDistance)
                {
                    PlayerControl.Instance.target = ememy;
                    minDistance = distance;
                }
            }
        }
        else
        {
            PlayerControl.Instance.target = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy) targets.Add(enemy);
            IsTargetOn = 0 < targets.Count ? true : false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
           
            if (enemy)
            {
                if (targets.Contains(enemy)) targets.Remove(enemy);
            }
            IsTargetOn = 0 < targets.Count ? true : false;
        }
    }
}
