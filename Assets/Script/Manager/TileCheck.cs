using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileCheck
{
    ILineCheck m_LineCheck;

    ICrossCheck m_CrossAllCheck;

    [SerializeField]
    List<Tile> m_matchTile;

    Mutex<TileCheck> m_Mutex;


    public TileCheck()
    {
        m_LineCheck = new LineCheckRay();
        m_CrossAllCheck = new CrossCheckAll();
        m_matchTile = new List<Tile>(SharedData.instance.MaxWidth * 2);
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
        ReSetChecking(true);
    }

    void HeightReSetChecking()
    {
        ReSetChecking(false);
    }

    void ReSetChecking(bool isWidth)
    {
        for (int i = 0; i < (isWidth ? SharedData.instance.MaxWidth : SharedData.instance.MaxHight); ++i)
        {
            m_LineCheck.LineChecking(isWidth, i, m_matchTile);

            if (m_matchTile.Count >= 3)
            {
                for(int j = 0; j < m_matchTile.Count; j += 3)
                {
                    m_Mutex.Enqueue(m_matchTile[j].ReSetting);
                }
                m_matchTile.Clear();
            }
        }
        m_Mutex.FirstCall(this);
    }

    public Mutex<TileCheck> GetMutex()
    {
        return m_Mutex;
    }

    public void CrossTileCheck(Transform stdFirstTransform, Transform stdSecondTransform)
    {
        m_matchTile.AddRange(m_CrossAllCheck.CrossChecking(stdFirstTransform));
        m_matchTile.AddRange(m_CrossAllCheck.CrossChecking(stdSecondTransform));
    }

    public bool IsMatchTile()
    {
        return m_matchTile.Count != 0;
    }

    public void MatchTileBreak()
    {
        foreach (var tile in m_matchTile)
        {
            if(tile.gameObject.activeSelf)
            tile.m_OnBreakTile?.Invoke(tile);
        }
        m_matchTile.Clear();
    }



}