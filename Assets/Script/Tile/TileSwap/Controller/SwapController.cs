using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class SwapController
{
    protected ISwap m_swap;

    public abstract void OnSwap(Tile firstTile, Tile secondTile, UnityAction action);
}
