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
                SetNodeIndexs(i, j, Random.Range(0, tilePrefab.GetMaxType()));
        }
    }
    public void SetNodeIndexs(int height, int width, int value)
    {
        m_NodeIndexs[height, width] = value;
    }

    public override int GetNodeType(int index)
    {
        return m_NodeIndexs[index / m_MaxHeight, index % m_MaxHeight];
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
