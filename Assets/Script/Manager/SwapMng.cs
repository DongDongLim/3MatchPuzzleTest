using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMng : SingleTonOnly<SwapMng>
{
    Tile m_CurSelectTile;

    ISwap m_SwapTile;


    protected override void OnAwake()
    {
        m_SwapTile = new SwapTileLerp();
    }

    public void ClearSelectTile()
    {
        m_CurSelectTile = null;
    }
    public void SetSelectTile(Tile targetTile)
    {
        m_CurSelectTile = targetTile;
    }

    public void SetSwapTile(Tile targetTile)
    {
        if (m_CurSelectTile == null)
            return;
        m_SwapTile.OnSwapSetting(m_CurSelectTile, targetTile);
        ClearSelectTile();
        StartCoroutine(SwapTile());
    }

    IEnumerator SwapTile()
    {
        for (float i = 0; i <= 1.0f; i += Time.deltaTime)
        {
            m_SwapTile.OnSwap(i);
            yield return null;
        }
    }
    
}
