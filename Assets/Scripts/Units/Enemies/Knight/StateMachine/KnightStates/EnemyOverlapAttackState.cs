using UnityEngine;
using UnityEngine.AI;

public class EnemyOverlapAttackState : EnemyState
{

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject _player;
    [SerializeField] private EnemyGoingToOverlapAttack _enemyGoingToOverlapAttack;
    [SerializeField] private Animator _animator;

    public override void Enter()
    {
        _agent.isStopped = true;
        CanChangeState = false;
        PlayAttackAnim(true);
    }

    public override void Exit()
    {
        PlayAttackAnim(false);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        _agent.transform.LookAt(_player.transform.position, _agent.transform.up);
        _agent.transform.eulerAngles = new Vector3(0, _agent.transform.eulerAngles.y, 0);
    }

    public void EndAnimationAttack()
    {
        _agent.isStopped = false;
        CanChangeState = true;
    }

    public void Attack()
    {
        _enemyGoingToOverlapAttack.PerformAttack();
    }

    public void PlayAttackAnim(bool isAttacking)
    {
        _animator.SetBool("IsAttacking", isAttacking);
    }
}
