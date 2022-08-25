using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Charactor : MonoBehaviour
{
    int m_CharNum;

    protected int CharNum {
        set { m_CharNum = value; }
        get { return m_CharNum; }
    }

    [SerializeField]
    protected int m_MaxSize;
     

    public bool IsSameChar(Charactor charactor)
    {
        return m_CharNum == charactor.m_CharNum;
    }

}
