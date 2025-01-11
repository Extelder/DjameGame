using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Rapier : MonoBehaviour
{
    [SerializeField] private KeyCode _attackKey;
    [SerializeField] private string _attackBoolAnimationName;
    [SerializeField] private Collider _bladeCollider;
    [field: SerializeField] public int Damage { get; private set; } 

    private Animator _animator;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_attackKey) && !Settings.Instance.Open)
        {
            _animator.SetBool(_attackBoolAnimationName, true);
        }

        if (Input.GetKeyUp(_attackKey))
        {
            _animator.SetBool(_attackBoolAnimationName, false);
        }
    }

    public void PerformAttack()
    {
        _bladeCollider.OnTriggerEnterAsObservable().Subscribe(_ =>
        {
            if (_.TryGetComponent<HitBox>(out HitBox hitBox))
            {
                
            }
        }).AddTo(_disposable);
    }
}