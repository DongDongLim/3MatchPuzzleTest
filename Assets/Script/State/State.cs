using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateAI m_Owner;

    public abstract void Init(StateAI owner, params object[] variable);

    public abstract void Enter();

    public abstract void StateUpdate();

    public abstract void Exit();
}
