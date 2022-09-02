using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateArray : StateArray
{
    public GameStateArray(int size, params GameState[] gameStates)
    {
        Debug.Assert(size == gameStates.Length);

        m_ArrayCount = size;
        m_States = new List<State>(size);
        
        for(int i = 0; i < size; ++i)
        {
            m_States.Add(gameStates[i]);
        }        
    }
}

public enum EGAMESTATE
{
    NONE = -1,
    INIT,
    CHECK,
    BREAK,
    STAY,

    SIZE,
}

public abstract class StateArray
{
    protected List<State> m_States;
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
    StateArray m_States;

    public State m_CurState;

    public virtual void InitAI()
    {
        m_CurState = m_States[0];
        m_CurState.Enter();
    }

    public void TransState(EGAMESTATE state)
    {
        m_CurState?.Exit(m_States[(int)state]);
    }
}
