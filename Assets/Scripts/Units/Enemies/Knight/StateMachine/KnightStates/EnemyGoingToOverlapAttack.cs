using System;
using System.Collections;
using EvolveGames;
using UnityEngine;

public class EnemyGoingToOverlapAttack : MonoBehaviour
{
    [SerializeField] private OverlapSettings _overlapSettings;

    public event Action PlayerAttacked;


    private void Awake()
    {
        StartCoroutine(TryingPerformAttack());
    }

    private IEnumerator TryingPerformAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.002f);
            TryPerformAttack();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void TryPerformAttack()
    {
        OverlapSphere();
        for (var i = 0; i < _overlapSettings.Size; i++)
        {
            var target = _overlapSettings.Colliders[i].gameObject;
            if(target.TryGetComponent<PlayerController>(out PlayerController player))
            {
                PlayerAttacked?.Invoke();
            }
        }
    }
    public void PerformAttack()
    {
    }

    private void OverlapSphere()
    {
        _overlapSettings.Colliders = new Collider[10];
        _overlapSettings.Size = Physics.OverlapSphereNonAlloc(_overlapSettings._overlapPoint.position + _overlapSettings._positionOffset,
            _overlapSettings._sphereRadius, _overlapSettings.Colliders,
            _overlapSettings._searchLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_overlapSettings._overlapPoint.position + _overlapSettings._positionOffset, _overlapSettings._sphereRadius);
    }
}
