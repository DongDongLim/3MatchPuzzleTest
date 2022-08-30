using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwapTileLerp : ISwap
{
    int m_SwapNum;
    Tile m_firstTile;
    Tile m_SecondTile;
    Vector2 m_FirstEndTarget;
    Vector2 m_SecondEndTarget;

    public bool OnSwap(float moveParsent)
    {
        m_firstTile.transform.position = Vector2.Lerp(m_SecondEndTarget, m_FirstEndTarget, moveParsent);
        m_SecondTile.transform.position = Vector2.Lerp(m_FirstEndTarget, m_SecondEndTarget, moveParsent);
        if(moveParsent >= 1.0f)
        {
            m_SwapNum = m_firstTile.m_PositionIndex;
            m_firstTile.m_PositionIndex = m_SecondTile.m_PositionIndex;
            m_SecondTile.m_PositionIndex = m_SwapNum;
            return true;
        }
        return false;
    }

    public void OnSwapSetting(Tile firstTarget, Tile secondTarget)
    {
        m_firstTile = firstTarget;
        m_SecondTile = secondTarget;
        m_FirstEndTarget = SharedData.instance.GetNodePosition(m_SecondTile.m_PositionIndex);
        m_SecondEndTarget = SharedData.instance.GetNodePosition(m_firstTile.m_PositionIndex);
    }
}
