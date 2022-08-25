using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Charactor : MonoBehaviour
{
    int m_CharNum;

    [SerializeField]
    protected int m_MaxSize;

    protected void SetChar(int num)
    {
        m_CharNum = num;
    }

    protected int GetChar()
    {
        return m_CharNum;
    }

    public bool IsSameChar(Charactor charactor)
    {
        return m_CharNum == charactor.m_CharNum;
    }

}
