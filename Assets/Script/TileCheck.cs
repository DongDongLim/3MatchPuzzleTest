using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour
{
    ILineCheck m_LineCheck;

    [SerializeField]
    List<Tile> m_matchTile;

    int m_checkCount;

    WaitForSeconds m_WaitForSeconds;

    private void Awake()
    {
        m_LineCheck = new LineCheckRay();
        m_matchTile = new List<Tile>(SharedData.instance.MaxWidth);
        SharedData.instance.OnStartGame += InitLineCheckAll;
    }

    void InitLineCheckAll()
    {
        m_WaitForSeconds = null;

        StartCoroutine(CorReSetting());
    }

    IEnumerator CorReSetting()
    {
        for (int i = 0; i < SharedData.instance.MaxWidth; ++i)
        {
            m_LineCheck.LineChecking(true, i, m_matchTile);

            if (m_matchTile.Count >= 3)
            {
                foreach (Tile tile in m_matchTile)
                {
                    tile.ReSetting();
                    yield return m_WaitForSeconds;
                }
                m_matchTile.Clear();
            }
        }

        for (int i = 0; i < SharedData.instance.MaxHight; ++i)
        {
            m_LineCheck.LineChecking(false, i, m_matchTile);

            if (m_matchTile.Count >= 3)
            {
                foreach (Tile tile in m_matchTile)
                {
                    tile.ReSetting();
                    yield return m_WaitForSeconds;
                }
                m_matchTile.Clear();
            }
        }
    }
}