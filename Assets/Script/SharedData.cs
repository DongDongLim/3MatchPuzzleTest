using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedData : SingleTonOnly<SharedData>
{
    [SerializeField]
    private int m_MaxWidth;
    [SerializeField]
    private int m_MaxHeight;

    private int m_MaxPoolCount;

    private int[,] m_NodeIndexs;

    public int MaxWidth { get { return m_MaxWidth; } }

    public int MaxHight { get { return m_MaxHeight; } }

    public int MaxPoolCount { get { return m_MaxPoolCount; } }

    public void SetNodeIndexs(int height, int width, int value)
    {
        m_NodeIndexs[height, width] = value;
    }

    public int GetNodeIndexs(int height, int width)
    {
        return m_NodeIndexs[height, width];
    }

    protected override void OnAwake()
    {
        m_NodeIndexs = new int[m_MaxHeight, m_MaxWidth];
        m_MaxPoolCount = m_MaxWidth * m_MaxHeight;
    }
}
