using UnityEngine;

public abstract class PlayerStateBase
{
    public abstract void Enter();
    public virtual void Exit() { }
    public virtual void ProcessInput() { }
    public virtual void Update() { }
}
