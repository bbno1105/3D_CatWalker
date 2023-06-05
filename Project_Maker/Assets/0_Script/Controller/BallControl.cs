using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : ControlBase<BallControl>
{
    [SerializeField] Ball ballPrefab;
    [SerializeField] Transform ballPoolParent;

    public Stack<Ball> BallPool = new Stack<Ball>();

    protected override void Awake()
    {
        base.Awake();
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
        while (BallPool.Count == 0)
        {
            CreateBall(10);
        }

        Ball newBall = BallPool.Pop();
        newBall.gameObject.SetActive(true);
        newBall.transform.position = _position;
        newBall.ShotBall(_direction, PData.ShotSpeed, PData.BallLifeTime, PData.ATTDMG);
    }

    void CreateBall(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Ball newBall = GameObject.Instantiate(ballPrefab, ballPoolParent);
            newBall.gameObject.SetActive(false);
        }
    }
}
