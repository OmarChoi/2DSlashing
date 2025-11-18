using UnityEngine;

public abstract class PlayerStateBase
{
    protected PlayerController _controller;
    protected float _speed = 1.0f;
    protected float _defaultSpeed = 1.0f;

    public PlayerStateBase(PlayerController controller)
    {
        _controller = controller;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void ProcessInput() { }
    public virtual void Update() { }
}
