
public abstract class GameState : State
{
    #region 타일 풀링

    protected TileMake m_TileMaker;

    #endregion
    public override abstract void Enter();

    public override abstract void StateUpdate();

    public override abstract void Exit(State NextState);

}
