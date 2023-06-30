using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{
    Coroutine cor_ShotBall;

    float damage;
    float shotSpeed;

    IObjectPool<Ball> managedPool;
    
    public void Initialize(Vector3 _startPos, Vector3 _direction, float _ShotSpeed, float _lifeTime, float _damage)
    {
        transform.position = _startPos;
        transform.forward = _direction;

        damage = _damage;
        shotSpeed = _ShotSpeed;

        Invoke("DestroyBall", _lifeTime);
    }

    public void SetManagedPool(IObjectPool<Ball> _pool)
    {
        managedPool = _pool;
    }
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
        transform.Translate(Vector3.forward * shotSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy target = other.GetComponent<Enemy>();
            if (target)
            {
                target.HitDamage(damage);
                gameObject.SetActive(false);
            }
        }
    }

    public void DestroyBall()
    {
        managedPool.Release(this);
    }
}
