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
        Invoke("CheckTest", 2f);
    }

    void CheckTest()
    {
        for(int i = 0; i < 9; ++i)
        {
            m_LineCheck.LineChecking(true, i, m_matchTile);
        }
    }
}