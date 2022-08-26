using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileCheck : MonoBehaviour
{
    ILineCheck m_LineCheck;

    [SerializeField]
    List<Tile> m_matchTile;

    int m_checkCount;

    WaitForSeconds m_WaitForSeconds;

    Mutex m_Mutex;


    private void Awake()
    {
        m_LineCheck = new LineCheckRay();
        m_matchTile = new List<Tile>(SharedData.instance.MaxWidth);
        m_Mutex = new Mutex();
        SharedData.instance.OnStartGame += InitLineCheckAll;
    }

    void InitLineCheckAll()
    {
        m_WaitForSeconds = null;
        m_Mutex.Enqueue(WidthReSetChecking);
        m_Mutex.Enqueue(HeightReSetChecking);
        m_Mutex.FirstCall();
    }


    void WidthReSetChecking()
    {
        StartCoroutine(CorReSetChecking(true));
    }

    void HeightReSetChecking()
    {
        StartCoroutine(CorReSetChecking(false));
    }

    IEnumerator CorReSetChecking(bool isWidth)
    {
        for (int i = 0; i < (isWidth ? SharedData.instance.MaxWidth : SharedData.instance.MaxHight); ++i)
        {
            m_LineCheck.LineChecking(isWidth, i, m_matchTile);

            if (m_matchTile.Count >= 3)
            {
                foreach (Tile tile in m_matchTile)
                {
                    tile.ReSetting();
                    yield return m_WaitForSeconds;
                }
                m_matchTile.Clear();
            }
        }
        m_Mutex.Dequeue();
        if (!m_Mutex.Empty())
            m_Mutex.FirstCall();
    }
}