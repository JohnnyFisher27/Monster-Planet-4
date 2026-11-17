using UnityEngine;

public abstract class EnemyStateMachine<T> : Enemy where T : EnemyStateMachine<T>
{
    public abstract EnemyState<T> InitialState { get; }
    public EnemyState<T> CurrentState;

    public override void Update()
    {
        base.Update();
    }
    public void ChangeState(EnemyState<T> newState)
    {
        CurrentState?.ExitState((T)this);
        CurrentState = newState;
        CurrentState.EnterState((T)this);
    }
}