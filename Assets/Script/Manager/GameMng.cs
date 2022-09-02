using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    
    private void Awake()
    {
        m_TileMaker = new TileMake();
        StartCoroutine(CorUpdate());
    }

    IEnumerator CorUpdate()
    {
        CreateTile();
        yield return null;
        SharedData.instance.OnStartGame?.Invoke();
    }

}
