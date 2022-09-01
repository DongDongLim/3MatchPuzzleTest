using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileMake
{

    GameObject m_activeObj;

    ObjectPooling m_Pooling;

    public TileMake()
    {
        m_Pooling = new ObjectPooling();
    }
    public GameObject ActiveTile(int index)
    {
        m_activeObj = m_Pooling.Pop();
        m_activeObj.GetComponent<Tile>().m_PositionIndex = index;
        m_activeObj.SetActive(true);
        return m_activeObj;
    }

    public void InActiveTile(Tile tile, UnityAction inActivAction = null)
    {
        inActivAction?.Invoke();
        m_Pooling.Push(tile.gameObject);
    }
    
    public void InActiveTile(GameObject tileObj, UnityAction inActivAction = null)
    {
        inActivAction?.Invoke();
        m_Pooling.Push(tileObj.gameObject);
    }
}
