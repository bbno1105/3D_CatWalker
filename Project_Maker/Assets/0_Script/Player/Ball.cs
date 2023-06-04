using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Coroutine cor_ShotBall;

    float damage;
    float shotSpeed;
    float lifeTime;

    public void ShotBall(Vector3 _direction, float _ShotSpeed, float _lifeTime, float _damage)
    {
        this.transform.forward = _direction;

        damage = _damage;
        shotSpeed = _ShotSpeed;
        lifeTime = _lifeTime;

        if (cor_ShotBall != null) StopCoroutine(cor_ShotBall);
        cor_ShotBall = StartCoroutine(ShotBallCoroutine());
    }

    IEnumerator ShotBallCoroutine()
    {
        float time = 0;
        while(time < lifeTime)
        {
            yield return new WaitForFixedUpdate();
            
            transform.position += transform.forward * shotSpeed * Time.fixedDeltaTime;
            time += Time.fixedDeltaTime;
        }
        gameObject.SetActive(false);
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

    void OnDisable()
    {
        BallControl.Instance.BallPool.Push(this);
    }
}
