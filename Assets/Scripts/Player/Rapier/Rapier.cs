using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Rapier : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _attackLayers;
    [SerializeField] private Pool _defaultHitPool;

    [SerializeField] private KeyCode _attackKey;
    [SerializeField] private string _attackBoolAnimationName;
    [SerializeField] private string _performAttackBoolAnimationName;
    [SerializeField] private string _obstacleAttackBoolAnimationName;
    [SerializeField] private AudioSource _chargeReady;
    [SerializeField] private AudioSource _performAttackSound;
    [SerializeField] private ParticleSystem _chargeParticle;
    [field: SerializeField] public int Damage { get; private set; }

    private Animator _animator;
    public event Action ChargingStart;
    public event Action ChargingEnd;

    private bool _charged;

    private bool _charging;

    public RaycastHit Hit;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(_camera.position, _camera.forward * _attackRange);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_attackKey) && !Settings.Instance.Open)
        {
            _charging = true;
            _animator.SetBool(_obstacleAttackBoolAnimationName, false);

            _animator.SetBool(_attackBoolAnimationName, true);
            _charged = false;
        }

        if (Input.GetKeyUp(_attackKey))
        {
            _charging = false;

            ChargingEnd?.Invoke();
            _animator.SetBool(_attackBoolAnimationName, false);
            if (_charged)
                _animator.SetBool(_performAttackBoolAnimationName, true);
        }
    }

    public void ChargeStart()
    {
        ChargingStart?.Invoke();
    }

    public void ChargedParticle()
    {
        if (_charging == true)
            _chargeParticle.Play();
    }

    public void ChargeAudio()
    {
        if (_charging == true)
            _chargeReady.Play();
    }

    public void ChargeReady()
    {
        _charged = true;
    }

    public void PerformAttack()
    {
        _charged = false;
        _performAttackSound.Play();
        _animator.SetBool(_performAttackBoolAnimationName, false);


        if (Physics.Raycast(_camera.position, _camera.forward, out Hit, _attackRange, _attackLayers))
        {
            if (Hit.collider.TryGetComponent<HitBox>(out HitBox hitBox))
            {
                hitBox.Hit(this);
            }
            else
            {
                PoolObject instance = _defaultHitPool.GetFreeElement(Hit.point);

                instance.transform.eulerAngles = Hit.normal;

                _animator.SetBool(_obstacleAttackBoolAnimationName, true);
            }
        }
    }
}