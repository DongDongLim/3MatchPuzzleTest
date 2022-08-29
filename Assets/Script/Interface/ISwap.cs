using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwap
{
    void OnSwapSetting(Tile firstTarget, Tile secondTarget);
    bool OnSwap(float moveParsent);
}
