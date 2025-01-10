using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [Header("States")]
    [SerializeField] private EnemyIdleState _idleEnemyState;
    [SerializeField] private EnemyPatrolState _patrolEnemyState;
    [SerializeField] private EnemyChaseState _chaseEnemyState;
    [SerializeField] private EnemyOverlapAttackState _overlapAttackEnemyState;

    [Header("Scripts")]
    [SerializeField] private EnemyPlayerDetect _playerDetect;
    [SerializeField] private EnemyGoingToOverlapAttack _enemyGoingToOverlapAttack;

    private void Awake()
    {
        Init(_idleEnemyState);
    }

    public void Idle()
    {
        ChangeState(_idleEnemyState);
    }

    public void Patrol()
    {
        ChangeState(_patrolEnemyState);
    }
    public void Chase()
    {
        ChangeState(_chaseEnemyState);
    }
    public void OverlapAttack()
    {
        if (CurrentState != _overlapAttackEnemyState)
        {
            CurrentState.CanChangeState = true;
        }
        ChangeState(_overlapAttackEnemyState);
    }

    private void Update()
    {
        CurrentState.StateUpdate();
    }

    private void OnEnable()
    {
        _playerDetect.PlayerDetected += Chase;
        _playerDetect.PlayerLost += Patrol;
        _enemyGoingToOverlapAttack.PlayerAttacked += OverlapAttack;
    }

    private void OnDisable()
    {
        _playerDetect.PlayerDetected -= Chase;
        _playerDetect.PlayerLost -= Patrol;
        _enemyGoingToOverlapAttack.PlayerAttacked -= OverlapAttack;
    }
}