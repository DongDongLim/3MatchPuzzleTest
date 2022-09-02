using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMonoBehaviour : SingleTonOnly<UseMonoBehaviour>
{
    protected override void OnAwake()
    {

    }

    public void OnStartCoroutine(IEnumerator cor)
    {
        StartCoroutine(cor);
    }

    public GameObject OnInstantiate(GameObject orisinal, Transform parent, bool worldPositionStays)
    {
        return Instantiate(orisinal, parent, false);
    }
}
