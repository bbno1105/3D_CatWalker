using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Damage : MonoBehaviour
{
    RectTransform rectTransform;

    public Vector3 ActivePos;
    public TextMeshProUGUI TxtDamage;

    void Awake()
    {
        rectTransform = transform.GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        ActivePos += Vector3.up * 0.5f;
        Vector2 position = Camera.main.WorldToScreenPoint(ActivePos);
        position.y += 50;
        position.x += 50 * Random.Range(-1, 1);
        rectTransform.position = position;
    }

    public void ActiveFalse()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        UIControl.Instance.DamagePool.Push(this);
    }
}
