using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SwapControllerLerp : SwapController
{
    public SwapControllerLerp()
    {
        m_swap = new SwapTileLerp();
    }

    public override void OnSwap(Tile firstTile, Tile secondTile, UnityAction action)
    {
        m_swap.OnSwap(firstTile, secondTile, action);
    }
}
