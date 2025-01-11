using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyIdleEnemyStateMachine : StateMachine
{
    [SerializeField] private EnemyIdleState _idleEnemyState;
    private void Awake()
    {
        Init(_idleEnemyState);
    }
}
