using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int m_PositionIndex;

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

}