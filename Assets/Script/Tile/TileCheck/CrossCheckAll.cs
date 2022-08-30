using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossCheckAll : ICrossCheck
{
    ILineCheck m_lineCheck;

    List<Tile> m_CrossCheckList;

    public CrossCheckAll()
    {
        m_lineCheck = new LineCheckRay();
        m_CrossCheckList = new List<Tile>(18);
    }

    public List<Tile> CrossChecking(Transform mine)
    {
        m_CrossCheckList.Clear();
        m_lineCheck.LineChecking(true, (int)SharedData.instance.GetPuzzleCoordinate(mine.GetComponent<Tile>().m_PositionIndex).x,
            m_CrossCheckList);
        m_lineCheck.LineChecking(false, (int)SharedData.instance.GetPuzzleCoordinate(mine.GetComponent<Tile>().m_PositionIndex).y,
            m_CrossCheckList);
        return m_CrossCheckList;
    }
}
