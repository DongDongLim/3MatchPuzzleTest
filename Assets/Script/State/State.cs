using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    StateAI m_Owner;

    public State(StateAI owner)
    {
        m_Owner = owner;
    }

    public abstract void Enter();

    public abstract void StateUpdate();

    public virtual void Exit(State NextState)
    {
        m_Owner.m_CurState = NextState;
        NextState.Enter();
    }
}
