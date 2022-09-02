
public abstract class GameState : State
{
    #region º¯¼ö

    protected TileMake m_TileMaker;

    protected TileCheck m_TileChecker;

    #endregion

    public override void Init(StateAI owner, params object[] variable)
    {
        m_Owner = owner;
        m_TileMaker = (TileMake)variable[0];
        m_TileChecker = (TileCheck)variable[1];
    }

    public override abstract void Enter();

    public override abstract void StateUpdate();

    public override abstract void Exit();

}
