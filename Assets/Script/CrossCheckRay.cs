using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossCheckRay : ICrossCheck
{
    RaycastHit2D[] m_hit;

    List<int> m_checkList;

    public List<int> CrossChecking(Tile mine)
    {
        m_checkList = new List<int>();

        m_hit = Physics2D.RaycastAll(SharedData.instance.GetNodePosition(mine.m_PositionIndex) + (Vector2.up * SharedData.instance.NodeDis), Vector2.down, SharedData.instance.NodeDis * 2, LayerMask.GetMask("Tile"));
        
        if(m_hit[0].collider != null)
        {
            foreach(var hit in m_hit)
                m_checkList.Add(hit.transform.GetComponent<Tile>().TileNum);
        }

        m_hit = Physics2D.RaycastAll(SharedData.instance.GetNodePosition(mine.m_PositionIndex) + (Vector2.left * SharedData.instance.NodeDis), Vector2.right, SharedData.instance.NodeDis * 2, LayerMask.GetMask("Tile"));
        
        if (m_hit[0].collider != null)
        {
            foreach (var hit in m_hit)
                m_checkList.Add(hit.transform.GetComponent<Tile>().TileNum);
        }

        return m_checkList;
    }
}
