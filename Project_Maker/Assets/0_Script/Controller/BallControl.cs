using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BallControl : ControlBase<BallControl>
{
    [SerializeField] Ball ballPrefab;
    [SerializeField] Transform ballPoolParent;

    IObjectPool<Ball> Pool;

    protected override void Awake()
    {
        base.Awake();
        Pool = new ObjectPool<Ball>(CreateBall, OnGetBall, OnReleaseBall, OnDestroyBall, maxSize:100);
    }

    public override void Open(PlayerData _pData)
    {
        base.Open(_pData);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public void ShotBall(Vector3 _position, Vector3 _direction)
    {
        var newBall = Pool.Get();
        newBall.Initialize(_position, _direction, PData.ShotSpeed, PData.BallLifeTime, PData.ATTDMG);
        newBall.gameObject.SetActive(true);
    }

    Ball CreateBall()
    {
        Ball newBall = GameObject.Instantiate(ballPrefab, ballPoolParent);
        newBall.SetManagedPool(Pool);
        return newBall;
    }

    void OnGetBall(Ball _ball)
    {
        _ball.gameObject.SetActive(true);
    }

    void OnReleaseBall(Ball _ball)
    {
        _ball.gameObject.SetActive(false);
    }

    void OnDestroyBall(Ball _ball)
    {
        Destroy(_ball.gameObject);
    }
}
