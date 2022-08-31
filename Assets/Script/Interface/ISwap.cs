using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public interface ISwap
{
    void OnSwap(Tile firstTarget, Tile secondTarget, UnityAction swapAction = null);
}
