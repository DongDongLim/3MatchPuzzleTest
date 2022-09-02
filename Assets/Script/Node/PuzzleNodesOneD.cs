using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNodesOneD : PuzzleNodes
{
    private void Awake()
    {
        m_MaxWidth = SharedData.instance.MaxWidth;
        m_MaxHeight = SharedData.instance.MaxHight;
        for (int i = 0; i < m_MaxHeight; ++i)
        {
            for (int j = 0; j < m_MaxWidth; ++j)
                SharedData.instance.SetNodeIndexs(i, j, (i * m_MaxWidth) + j);
        }
    }

    public override Vector2 GetNodePosition(int index)
    {
        return transform.GetChild(index).position;
    }
    public override Vector2 GetNodeCoordinate(int index)
    {
        return new Vector2(index / m_MaxWidth, index % m_MaxWidth);
    }
}
