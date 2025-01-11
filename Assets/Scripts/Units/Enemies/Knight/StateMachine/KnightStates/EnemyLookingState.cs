using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLookingState : EnemyState
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _maxCooldown;
    [SerializeField] private EnemyStateMachine _stateMachine;
    [SerializeField] private Animator _animator;

    public override void Enter()
    {
        Debug.Log("looking");
        _agent.isStopped = true;
        CanChangeState = false;
        PlayLookingAnim(true);
        StartCoroutine(GoToPatrol());
    }

    private IEnumerator GoToPatrol()
    {
        float cooldown = Random.Range(0, _maxCooldown);
        yield return new WaitForSeconds(cooldown);
        CanChangeState = true;
        _stateMachine.Patrol();
    }
    
    public void PlayLookingAnim(bool isLooking)
    {
        _animator.SetBool("IsLooking", isLooking);
    }
    public override void Exit()
    {
        _agent.isStopped = false;
        StopAllCoroutines();
        PlayLookingAnim(false);
    }
}
