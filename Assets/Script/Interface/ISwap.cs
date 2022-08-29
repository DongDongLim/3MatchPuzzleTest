using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwap
{
    void OnSwapSetting(Tile firstTarget, Tile secondTarget);
    void OnSwap(float moveParsent);
}
