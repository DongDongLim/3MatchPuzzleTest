using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPooling
{
    Queue<GameObject> poolingObj = new Queue<GameObject>();

    // Ǯ���� �߰��ϴ� �뵵
    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        poolingObj.Enqueue(obj);

    }

    // Ǯ������ ���� �뵵
    public GameObject Pop(Vector3 pos = new Vector3(), Vector3 rotate = new Vector3())
    {
        GameObject obj = poolingObj.Dequeue();
        if (Vector3.zero == pos)
            pos = obj.transform.position;
        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.Euler(rotate);
        return obj;
    }

}