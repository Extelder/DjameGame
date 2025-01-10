using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyState
{

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _animator;

    public override void Enter()
    {
        PlayRunAnim(true);
        Debug.Log("DOGONYALKKIIII");
    }

    public override void Exit()
    {
        PlayRunAnim(false);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        _agent.SetDestination(_player.transform.position);
    }

    public void PlayRunAnim(bool isRunning)
    {
        _animator.SetBool("IsRunning", isRunning);
    }
}
