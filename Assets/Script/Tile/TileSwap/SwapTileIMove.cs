using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwapTileIMove : ISwap
{
    int m_FirstTileNum;
    int m_SecondTileNum;
    Tile m_firstTile;
    Tile m_SecondTile;
    UnityAction m_swapAction;

    void FirstToSecondSwap()
    {
        m_firstTile.m_PositionIndex = m_SecondTileNum;
        m_swapAction?.Invoke();
    }

    void SecondToFirstSwap()
    {
        m_SecondTile.m_PositionIndex = m_FirstTileNum;
        m_swapAction?.Invoke();
    }


    public void OnSwap(Tile firstTarget, Tile secondTarget, UnityAction swapAction = null)
    {
        m_firstTile = firstTarget;
        m_SecondTile = secondTarget;
        m_FirstTileNum = m_firstTile.m_PositionIndex;
        m_SecondTileNum = m_SecondTile.m_PositionIndex;
        m_swapAction = swapAction;
        m_firstTile.GetComponent<IMove>().OnMove(m_SecondTileNum, FirstToSecondSwap);
        m_SecondTile.GetComponent<IMove>().OnMove(m_FirstTileNum, SecondToFirstSwap);
    }
}
