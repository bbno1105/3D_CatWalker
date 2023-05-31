using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    Coroutine Cor_UI;
    RectTransform rectTransform;

    [HideInInspector] public Enemy target;
    public TextMeshProUGUI HP;
    public Slider HPSlider;
    public float ActiveTime;
    public RectTransform DamagePos;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        if (target == null) return;


        Initialize();

        if (Cor_UI != null) StopCoroutine(Cor_UI);
        Cor_UI = StartCoroutine(UICoroutine());
    }

    public void Initialize()
    {
        HP.text = target.NowHP.ToString();
        HPSlider.value = target.NowHP / target.MaxHp;

        ActiveTime = 2;
    }

    IEnumerator UICoroutine()
    {
        
        while(0 < ActiveTime)
        {
            if (target.NowHP <= 0) break;
            
            UIPosition();

            ActiveTime -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        gameObject.SetActive(false);
    }

    public void UIPosition()
    {
        Vector3 newPosition = target.transform.position;
        newPosition += Vector3.up * 0.5f;

        Vector2 position = Camera.main.WorldToScreenPoint(newPosition);
        rectTransform.position = position;
    }

    void OnDisable()
    {
        if (target != null) target.HPUI = null;
        UIControl.Instance.EnemyUIPool.Push(this);
    }
}
