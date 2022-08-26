using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineCheckRay : ILineCheck
{
    RaycastHit2D[] m_hit;

    int m_distance;

    Vector2 m_dir;

    List<Tile> tileList = new List<Tile>(SharedData.instance.MaxWidth);

    public void LineChecking(bool isWidth, int stdIndex, List<Tile> matchTile)
    {
        if (isWidth)
        {
            m_distance = SharedData.instance.MaxWidth - 1;

            m_dir = Vector2.right;

            m_hit = Physics2D.RaycastAll(SharedData.instance.GetNodePosition(stdIndex, 0),
                m_dir, SharedData.instance.NodeDis * m_distance, LayerMask.GetMask("Tile"));
        }
        else
        {
            m_distance = SharedData.instance.MaxHight - 1;

            m_dir = Vector2.down;

            m_hit = Physics2D.RaycastAll(SharedData.instance.GetNodePosition(0, stdIndex),
                m_dir, SharedData.instance.NodeDis * m_distance, LayerMask.GetMask("Tile"));
        }

        if (m_hit.Length == 0)
        {
            Debug.Log(true);
            return;
        }
        tileList.Clear();

        tileList.Add(m_hit[0].transform.GetComponent<Tile>());

        for(int i = 1; i < m_hit.Length; ++i)
        {
            if (m_hit[i].transform.GetComponent<Tile>().IsSameTile(tileList[tileList.Count - 1]))
                tileList.Add(m_hit[i].transform.GetComponent<Tile>());
            else
            {
                if (tileList.Count >= 3)
                {
                    foreach (var tile in tileList)
                        matchTile.Add(tile);
                }
                tileList.Clear();
                tileList.Add(m_hit[i].transform.GetComponent<Tile>());
            }
        }
        if (tileList.Count >= 3)
        {
            foreach (var tile in tileList)
                matchTile.Add(tile);
        }
    }
}
