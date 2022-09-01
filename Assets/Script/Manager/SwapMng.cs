using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMng : MonoBehaviour
{
    SwapController m_SwapTile;

    Tile m_CurSelectTile;
    Tile m_CurSwapTile;

    bool isSwap = false;

    bool isSwapRetrun = false;

    private void Awake()
    {
        m_SwapTile = new SwapControllerIMove();
        SharedData.instance.OnSelectTile = SetSelectTile;
        SharedData.instance.OnSwapTile = SetSwapTile;
        SharedData.instance.OnClearSelectTile = ClearSelectTile;
    }

    public void ClearSelectTile()
    {
        if (isSwap)
            return;
        m_CurSelectTile = null;
        m_CurSwapTile = null;
    }
    public void SetSelectTile(Tile targetTile)
    {
        if (isSwap)
            return;
        m_CurSelectTile = targetTile;
    }

    public void SetSwapTile(Tile targetTile)
    {
        if (m_CurSelectTile == null)
            return;
        if (!m_CurSelectTile.IsCrossTile(targetTile))
            return;
        if (isSwap)
            return;
        isSwap = true;
        m_CurSwapTile = targetTile;
        m_SwapTile.OnSwap(m_CurSelectTile, m_CurSwapTile, SwapAction);
    }

    public void SwapAction()
    {
        if (isSwapRetrun)
        {
            isSwapRetrun = false;
            isSwap = false;
            ClearSelectTile();
            return;
        }

        SharedData.instance.CrossTileCheck(m_CurSelectTile.transform);
        SharedData.instance.CrossTileCheck(m_CurSwapTile.transform);

        if (SharedData.instance.MatchTileBreak())
        {
            isSwap = false;
            ClearSelectTile();
        }
        else
        {
            isSwapRetrun = true;
            m_SwapTile.OnSwap(m_CurSwapTile, m_CurSelectTile, SwapAction);
        }
    }    
}
