using UnityEngine;

public abstract class EnemyState<T> where T : EnemyStateMachine<T>
{
    public abstract void EnterState(T enemy);
    //use UpdateState to change states
    public abstract void UpdateState(T enemy);
    //use ExitState to finalize any data not for updating states
    public abstract void ExitState(T enemy);
        
}
