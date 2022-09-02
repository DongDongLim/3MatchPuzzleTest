using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : GameState
{
    #region 타일 풀링

    [SerializeField]
    private GameObject m_TilePrefab;

    [SerializeField]
    private Transform m_TileParant;

    #endregion

    public InitState()
    {
        m_TilePrefab = SharedData.instance.TilePrefab;
        m_TileParant = SharedData.instance.TileParant;
    }
    public override void Init(StateAI owner, params object[] variable)
    {
        base.Init(owner, variable);
    }

    public override void Enter()
    {
        CreateTile();
        m_TileChecker.isInit = false;
    }

    public override void Exit()
    {

    }

    public override void StateUpdate()
    {
        m_Owner.TransState(SharedData.EGAMESTATE.CHECK);
    }

    public void CreateTile()
    {
        GameObject m_activeObj;
        for (int i = 0; i < SharedData.instance.MaxPoolCount; ++i)
        {
            m_TileMaker.InActiveTile(UseMonoBehaviour.instance.OnInstantiate(m_TilePrefab, m_TileParant, false));
            m_activeObj = m_TileMaker.ActiveTile(i);
            m_activeObj.transform.position = new Vector3(SharedData.instance.GetNodePosition(i).x, SharedData.instance.GetNodePosition(i).y, 0);
            m_activeObj.GetComponent<Tile>().m_OnBreakTile = new Tile.OnBreakTile(m_TileMaker.InActiveTile);
        }

    }

}
