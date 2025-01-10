using UnityEngine;

public abstract class State : MonoBehaviour
{
    public bool CanChangeState = true;

    public abstract void Enter();
    public virtual void Exit() { }
    public virtual void StateUpdate() { }
}
