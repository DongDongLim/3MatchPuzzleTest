
public abstract class GameState : State
{
    #region Ÿ�� Ǯ��

    protected TileMake m_TileMaker;

    #endregion
    public override abstract void Enter();

    public override abstract void StateUpdate();

    public override abstract void Exit(State NextState);

}
