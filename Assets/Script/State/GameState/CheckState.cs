using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckState : GameState
{
    List<Tile> m_matchTile;

    public override void Init(StateAI owner, params object[] variable)
    {
        base.Init(owner, variable);
    }

    public override void Enter()
    {
        m_TileChecker.InitLineCheckAll();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void StateUpdate()
    {

    }
}
