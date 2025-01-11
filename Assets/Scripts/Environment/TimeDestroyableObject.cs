using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyableObject : DestroyObject
{
    [SerializeField] private EnvironmentHealth _health;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _health.ObjectDestroyed += () => Destroy();
    }

    public override void Destroy()
    {
        _animator.SetTrigger("TimeAnim");
        base.Destroy();
    }

    private void OnDisable()
    {
        _health.ObjectDestroyed -= () => Destroy();
    }
}
