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
        rectTransform.position = ActivePos;
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
