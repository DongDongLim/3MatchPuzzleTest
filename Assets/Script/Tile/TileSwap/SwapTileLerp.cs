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
    UnityAction m_MoveEnbAction;

    IEnumerator Swap()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * SharedData.instance.SwapSpeed; 
            m_firstTile.transform.position = Vector2.Lerp(m_SecondEndTarget, m_FirstEndTarget, t);
            m_SecondTile.transform.position = Vector2.Lerp(m_FirstEndTarget, m_SecondEndTarget, t);
            yield return null;
        }
        m_SwapNum = m_firstTile.m_PositionIndex;
        m_firstTile.m_PositionIndex = m_SecondTile.m_PositionIndex;
        m_SecondTile.m_PositionIndex = m_SwapNum;
        m_MoveEnbAction?.Invoke();
    }

    public void OnSwap(Tile firstTarget, Tile secondTarget, UnityAction swapAction = null)
    {
        m_firstTile = firstTarget;
        m_SecondTile = secondTarget;
        m_FirstEndTarget = SharedData.instance.GetNodePosition(m_SecondTile.m_PositionIndex);
        m_SecondEndTarget = SharedData.instance.GetNodePosition(m_firstTile.m_PositionIndex);
        m_MoveEnbAction = swapAction;
        SharedData.instance.OnStartCoroutine(Swap());
    }
}
