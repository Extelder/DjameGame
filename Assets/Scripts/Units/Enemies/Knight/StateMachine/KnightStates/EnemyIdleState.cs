using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : EnemyState
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _maxCooldown;
    [SerializeField] private EnemyStateMachine _stateMachine;

    public override void Enter()
    {
        Debug.Log("stoy");
        _agent.isStopped = true;
        CanChangeState = false;
        StartCoroutine(GoToPatrol());
    }

    private IEnumerator GoToPatrol()
    {
        float cooldown = Random.Range(0, _maxCooldown);
        yield return new WaitForSeconds(cooldown);
        CanChangeState = true;
        _stateMachine.Patrol();
    }

    public override void Exit()
    {
        _agent.isStopped = false;
    }
}
