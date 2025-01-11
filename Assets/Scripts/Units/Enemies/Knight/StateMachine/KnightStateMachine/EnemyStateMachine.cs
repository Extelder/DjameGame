using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [Header("States")]
    [SerializeField] private EnemyIdleState _idleEnemyState;
    [SerializeField] private EnemyPatrolState _patrolEnemyState;
    [SerializeField] private EnemyChaseState _chaseEnemyState;
    [SerializeField] private EnemyOverlapAttackState _overlapAttackEnemyState;
    [SerializeField] private EnemyLookingState _lookEnemyState;

    [Header("Scripts")]
    [SerializeField] private FieldOfView _playerDetect;
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
        if (CurrentState == _lookEnemyState)
        {
            CurrentState.CanChangeState = true;
        }
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

    public void Look()
    {
        if(CurrentState == _chaseEnemyState || CurrentState == _overlapAttackEnemyState)
            ChangeState(_lookEnemyState);
    }

    private void Update()
    {
        CurrentState.StateUpdate();
    }

    private void OnEnable()
    {
        _playerDetect.PlayerDetected += Chase;
        _playerDetect.PlayerLost += Look;
        _enemyGoingToOverlapAttack.PlayerAttacked += OverlapAttack;
    }

    private void OnDisable()
    {
        _playerDetect.PlayerDetected -= Chase;
        _playerDetect.PlayerLost -= Look;
        _enemyGoingToOverlapAttack.PlayerAttacked -= OverlapAttack;
    }
}