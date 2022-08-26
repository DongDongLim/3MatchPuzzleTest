using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    int m_TileNum;

    protected int TileNum {
        set { m_TileNum = value; }
        get { return m_TileNum; }
    }

    [SerializeField]
    protected int m_MaxSize;
     
    public int m_PositionIndex;

    public bool IsSameTile(Tile Tileactor)
    {
        return m_TileNum == Tileactor.m_TileNum;
    }

}
