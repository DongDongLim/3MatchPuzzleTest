using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(CorUpdate());
    }

    IEnumerator CorUpdate()
    {
        yield return new WaitForFixedUpdate();
        SharedData.instance.OnStartGame?.Invoke();
    }
}
