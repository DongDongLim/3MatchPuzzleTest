using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNodes : MonoBehaviour
{
    private int m_MaxWidth;
    private int m_MaxHeight;
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

    public Vector2 GetPuzzleNode(int index)
    {
        return transform.GetChild(index).position;
    }

}
