using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StateArray
{
    protected State[] m_States;
    protected int m_ArrayCount;

    public State this[int index]
    {
        get
        {
            if (index >= 0 && index < m_ArrayCount)
                return m_States[index];
            else
                return null;
        }
    }
}

public abstract class StateAI
{
    protected StateArray m_States;

    public State m_CurState;

    public virtual void InitAI()
    {
        TransState(0);
    }

    public void TransState(SharedData.EGAMESTATE state)
    {
        m_CurState?.Exit();
        m_CurState = m_States[(int)state];
        m_CurState.Enter();
    }
}
