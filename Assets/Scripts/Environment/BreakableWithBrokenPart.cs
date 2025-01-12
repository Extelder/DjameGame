using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWithBrokenPart : HitBox
{
    [SerializeField] private GameObject _normalObject;
    [SerializeField] private GameObject _brokenObject;
    [SerializeField] private bool _destroyScriptAfterBroke;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void DefaultVisit()
    {
        _normalObject.SetActive(false);
        _brokenObject.SetActive(true);
        _collider.enabled = false;
        if (_destroyScriptAfterBroke)
            Destroy(this);
    }

    public override void Hit(Rapier rapier)
    {
        base.Hit(rapier);
        DefaultVisit();
    }
}