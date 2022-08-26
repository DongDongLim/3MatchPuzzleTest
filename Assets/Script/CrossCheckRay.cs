using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossCheckRay : ICrossCheck
{
    RaycastHit2D[] m_hit;

    Vector2[] m_DirVector = { Vector2.up, Vector2.down, Vector2.left, Vector2.right, Vector2.zero };

    List<int> m_checkList;

    public List<int> CrossChecking(Transform mine)
    {
        m_checkList = new List<int>();

        m_hit = new RaycastHit2D[m_DirVector.Length];

        for(int i = 0; i < m_DirVector.Length; ++i)
        {
            m_hit[i] = Physics2D.Raycast((Vector2)mine.position + (m_DirVector[i] * SharedData.instance.TileSize), Vector2.up, 1, LayerMask.GetMask("Tile"));

            if (m_hit[i].collider != null)
            {
                m_checkList.Add(m_hit[i].transform.GetComponent<Tile>().TileNum);
            }
        }

        return m_checkList;
    }
}
