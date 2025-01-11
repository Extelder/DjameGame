using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void Hit(Rapier rapier)
    {
        _health.TakeDamage(rapier.Damage);
    }
}