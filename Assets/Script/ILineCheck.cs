using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILineCheck
{
    void Checking(bool isWidth, int heightIndex, ref List<Tile> matchTile);
}
