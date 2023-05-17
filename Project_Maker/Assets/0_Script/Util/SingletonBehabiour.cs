using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehabiour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    virtual protected void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
            return;
        }
        instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}
