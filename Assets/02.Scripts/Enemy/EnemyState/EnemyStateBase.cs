using UnityEngine;

public abstract class EnemyStateBase
{
    public virtual void Enter() { }
    public virtual void Exit() { }
    public abstract void Update();
}
