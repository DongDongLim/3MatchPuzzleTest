using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour
{
    ILineCheck m_LineCheck;

    [SerializeField]
    List<Tile> m_matchTile;

    private void Awake()
    {
        m_LineCheck = new LineCheckRay();
        m_matchTile = new List<Tile>(SharedData.instance.MaxWidth);
    }
}