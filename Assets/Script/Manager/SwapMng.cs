using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMng : SingleTonOnly<SwapMng>
{
    [SerializeField]
    int m_SwapSpeed;

    Tile m_CurSelectTile;

    ISwap m_SwapTile;

    bool isSwap = false;


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
        if (isSwap)
            return;
        m_CurSelectTile = targetTile;
    }

    public void SetSwapTile(Tile targetTile)
    {
        if (m_CurSelectTile == null)
            return;
        isSwap = true;
        m_SwapTile.OnSwapSetting(m_CurSelectTile, targetTile);
        ClearSelectTile();
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
        isSwap = false;
    }
    
}
