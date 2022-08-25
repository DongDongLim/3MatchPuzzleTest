using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleTonOnly<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (null == _instance)
        {
            _instance = GetComponent<T>();
            OnAwake();
        }
    }

    protected abstract void OnAwake();

    private void OnDestroy()
    {
        _instance = null;
    }

}