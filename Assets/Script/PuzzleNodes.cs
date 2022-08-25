using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNodes : MonoBehaviour
{
    [SerializeField]
    private int m_MaxWidth;
    [SerializeField]
    private int m_MaxHeight;
    public int[,] m_NodeIndexs;
    private void Awake()
    {
        m_NodeIndexs = new int[m_MaxHeight, m_MaxWidth];
        for (int i = 0; i < m_MaxHeight; ++i)
        {
            for (int j = 0; j < m_MaxWidth; ++j)
                m_NodeIndexs[i, j] = (i * m_MaxWidth) + j;
        }
    }

    public Vector2 GetPuzzleNode(int index)
    {
        return transform.GetChild(index).position;
    }

}
