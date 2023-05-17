using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    [SerializeField] GameObject _joyStickObject;
    RectTransform _joySticPosition;

    RectTransform _stickPosition;
    [SerializeField, Range(0,1)] float _minStickRange; // 0.1
    [SerializeField] float _maxStickRange; // 130

    Vector2 _touchPoint; // 조이스틱 터치 포인트

    bool _isButtonDowning;

    void Awake() 
    {
        _joySticPosition = _joyStickObject.GetComponent<RectTransform>();
        _stickPosition = _joyStickObject.transform.GetChild(1).GetComponent<RectTransform>(); // TestCode : 자식 순서로 찾고 있으니 추후 수정필요
    }

    void Start()
    {
        _joyStickObject.SetActive(false);
    }

    void Update()
    {
        InputJoyStick();
    }
    void InputJoyStick()
    {
        // TODO : 특정 공간에만 적용되도록 수정 필요
        if (Input.GetMouseButtonDown(0) && _isButtonDowning)
        {
            SetTouchPoint();
            _joyStickObject.SetActive(true);
        }

        if (Input.GetMouseButton(0) && _isButtonDowning)
        {

            Vector2 _moveDirection = (Input.mousePosition - _joySticPosition.position).normalized; // 조이스틱 방향
            float _distance = Vector2.Distance(Input.mousePosition, _joySticPosition.position); // 조이스틱 거리

            _distance = _distance < _maxStickRange ? _distance / _maxStickRange : 1;

            if (_minStickRange < _distance) // 일정 범위 컨트롤해야 움직일 수 있도록 설정
            {
                PlayerControl.Instance.MoveDirection = _moveDirection;
                PlayerControl.Instance.MoveRate = _distance;
            }

            _stickPosition.position = _joySticPosition.position + new Vector3(_moveDirection.x, _moveDirection.y, 0) * _maxStickRange * _distance;
        }

        if (Input.GetMouseButtonUp(0) && !_isButtonDowning)
        {
            PlayerControl.Instance.MoveRate = 0;

            _joyStickObject.SetActive(false);
            _stickPosition.position = _joySticPosition.position;

        }
    }

    void SetTouchPoint()
    {
        _joySticPosition.position = Input.mousePosition;
    }

    public void PointDown()
    {
        _isButtonDowning = true;
    }

    public void PointUP()
    {
        _isButtonDowning = false;
    }
}
