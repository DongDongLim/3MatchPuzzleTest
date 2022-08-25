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

    public int MaxWidth { get { return m_MaxWidth; } }

    public int MaxHight { get { return m_MaxHeight; } }

    public int MaxPoolCount { get { return m_MaxPoolCount; } }

    protected override void OnAwake()
    {
        m_MaxPoolCount = m_MaxWidth * m_MaxHeight;
    }
}
