using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateArray : StateArray
{
    #region ????

    public TileMake m_TileMaker;

    public TileCheck m_TileChecker;

    #endregion

    public GameStateArray(int size, StateAI ownerAI, params GameState[] gameStates)
    {
        Debug.Assert(size == gameStates.Length);

        m_ArrayCount = size;
        m_States = gameStates;
        m_TileMaker = new TileMake();
        m_TileChecker = new TileCheck();

        foreach (var state in m_States)
            state.Init(ownerAI, m_TileMaker, m_TileChecker);
    }
}

public class GameStateAI : StateAI
{
    public override void InitAI()
    {
        m_States = new GameStateArray(
            (int)SharedData.EGAMESTATE.SIZE
            , this
            , new InitState()
            , new CheckState()
            , new BreakState()
            , new StayState());
        base.InitAI();
    }
}
