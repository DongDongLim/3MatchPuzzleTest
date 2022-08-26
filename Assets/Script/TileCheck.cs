using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileCheck : MonoBehaviour
{
    ILineCheck m_LineCheck;

    [SerializeField]
    List<Tile> m_matchTile;

    Mutex<TileCheck> m_Mutex;


    private void Awake()
    {
        m_LineCheck = new LineCheckRay();
        m_matchTile = new List<Tile>(SharedData.instance.MaxWidth);
        m_Mutex = new Mutex<TileCheck>();
        SharedData.instance.OnStartGame += InitLineCheckAll;
    }

    void InitLineCheckAll()
    {
        WidthReSetChecking();
        HeightReSetChecking();
    }


    void WidthReSetChecking()
    {
        CorReSetChecking(true);
    }

    void HeightReSetChecking()
    {
        CorReSetChecking(false);
    }

    void CorReSetChecking(bool isWidth)
    {
        for (int i = 0; i < (isWidth ? SharedData.instance.MaxWidth : SharedData.instance.MaxHight); ++i)
        {
            m_LineCheck.LineChecking(isWidth, i, m_matchTile);

            if (m_matchTile.Count >= 3)
            {
                foreach (Tile tile in m_matchTile)
                {
                    m_Mutex.Enqueue(tile.ReSetting);
                    tile.ReSetting(this);
                }
                m_matchTile.Clear();
            }
        }
    }

    public Mutex<TileCheck> GetMutex()
    {
        return m_Mutex;
    }
}