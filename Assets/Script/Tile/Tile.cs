using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Tile : MonoBehaviour
{
    [SerializeField]
    int m_TileNum;

    public int TileNum {
        protected set { m_TileNum = value; }
        get { return m_TileNum; }
    }

    protected RandNum m_RandNum;

    protected ICrossCheck m_CrossCheck;

    protected List<Tile> m_CrossTile;

    public int m_PositionIndex;

    public delegate void OnBreakTile(Tile tile, UnityAction breakAction);

    public OnBreakTile m_OnBreakTile;

    private void Awake()
    {
        m_RandNum = new RandNum();
        m_CrossCheck = new CrossCheckRay();
    }

    public bool IsSameTile(Tile Tileactor)
    {
        return m_TileNum == Tileactor.m_TileNum;
    }

    public abstract void ReSetting(TileCheck tileCheck);

    public abstract int GetMaxType();

    public void CrossCheck()
    {
        m_CrossTile = m_CrossCheck.CrossChecking(transform);
    }

    public bool IsCrossTile(Tile tile)
    {
        CrossCheck();
        return m_CrossTile.Contains(tile);
    }

    public void TileBreak()
    {
        transform.position = (Vector2)transform.position
            + (Vector2.up * SharedData.instance.NodeDis * (SharedData.instance.GetPuzzleCoordinate(m_PositionIndex).x + 1));
        m_OnBreakTile(this, null);
    }

    public void MoveAction()
    {
        SharedData.instance.CrossTileCheck(transform);
    }
}
