using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwap
{
    void OnSwap(Tile firstTarget, Tile secondTarget, float moveParsent);
}
