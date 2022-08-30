using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMng : SingleTonOnly<SwapMng>
{
    [SerializeField]
    int m_SwapSpeed;

    Tile m_CurSelectTile;
    Tile m_CurSwapTile;

    ISwap m_SwapTile;

    bool isSwap = false;

    bool isSwapRetrun = false;

    TileCheck m_TileChecker;


    protected override void OnAwake()
    {
        m_SwapTile = new SwapTileLerp();
        m_TileChecker = new TileCheck();
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
        m_SwapTile.OnSwapSetting(m_CurSelectTile, m_CurSwapTile);
        StartCoroutine(SwapTile());
    }

    IEnumerator SwapTile()
    {
        float i = 0;
        while(!m_SwapTile.OnSwap(i))
        {
            i += Time.deltaTime * m_SwapSpeed;
            yield return null;
        }

        if(isSwapRetrun)
        {
            isSwapRetrun = false;
            isSwap = false;
            ClearSelectTile();
            yield break;
        }

        m_TileChecker.CrossTileCheck(m_CurSelectTile.transform);

        m_TileChecker.CrossTileCheck(m_CurSwapTile.transform);

        if (m_TileChecker.IsMatchTile())
        {
            m_TileChecker.MatchTileBreak();
            isSwap = false;
            ClearSelectTile();
        }
        else
        {
            m_SwapTile.OnSwapSetting(m_CurSwapTile, m_CurSelectTile);
            isSwapRetrun = true;
            StartCoroutine(SwapTile());
        }
    }
    
}
