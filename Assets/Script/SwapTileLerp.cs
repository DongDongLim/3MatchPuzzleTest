using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTileLerp : ISwap
{
    Vector2 m_FirstEndTarget;
    Vector2 m_SecondEndTarget;

    public void OnSwap(Tile firstTarget, Tile secondTarget, float moveParsent)
    {
        m_FirstEndTarget = SharedData.instance.GetNodePosition(secondTarget.m_PositionIndex);
        m_SecondEndTarget = SharedData.instance.GetNodePosition(firstTarget.m_PositionIndex);
        firstTarget.transform.position = Vector2.Lerp(m_SecondEndTarget, m_FirstEndTarget, moveParsent);
        secondTarget.transform.position = Vector2.Lerp(m_FirstEndTarget, m_SecondEndTarget, moveParsent);
    }

    
}
