using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTileLerp : ISwap
{
    Tile m_firstTile;
    Tile m_SecondTile;
    Vector2 m_FirstEndTarget;
    Vector2 m_SecondEndTarget;

    public void OnSwap(float moveParsent)
    {
        m_firstTile.transform.position = Vector2.Lerp(m_SecondEndTarget, m_FirstEndTarget, moveParsent);
        m_SecondTile.transform.position = Vector2.Lerp(m_FirstEndTarget, m_SecondEndTarget, moveParsent);
    }

    public void OnSwapSetting(Tile firstTarget, Tile secondTarget)
    {
        m_firstTile = firstTarget;
        m_SecondTile = secondTarget;
        m_FirstEndTarget = SharedData.instance.GetNodePosition(m_SecondTile.m_PositionIndex);
        m_SecondEndTarget = SharedData.instance.GetNodePosition(m_firstTile.m_PositionIndex);
    }
}
