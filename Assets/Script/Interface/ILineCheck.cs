using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILineCheck
{
    void LineChecking(bool isWidth, int heightIndex, List<Tile> matchTile, bool isMatch = true, int startIndex = 0);
}
