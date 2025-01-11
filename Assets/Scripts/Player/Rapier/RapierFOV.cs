using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RapierFOV : MonoBehaviour
{
    [SerializeField] private Rapier _rapier;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _chargeLerpSpeed;
    [SerializeField] private float _deChargeLerpSpeed;
    [SerializeField] private float _chargedFov;

    private float _targetFOV;
    private float _defaultFOV;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        _defaultFOV = _camera.fieldOfView;
    }

    private void OnEnable()
    {
        _rapier.ChargingStart += OnChargingStart;
        _rapier.ChargingEnd += OnChargingEnd;
    }

    private void OnDisable()
    {
        _rapier.ChargingStart -= OnChargingStart;
        _rapier.ChargingEnd -= OnChargingEnd;
    }


    private void OnChargingStart()
    {
        _disposable.Clear();
        _targetFOV = _chargedFov;
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _targetFOV, _chargeLerpSpeed * Time.deltaTime);
            if (Mathf.Round(_camera.fieldOfView) >= _targetFOV)
                _disposable.Clear();
        }).AddTo(_disposable);
    }

    private void OnChargingEnd()
    {
        _disposable.Clear();
        _targetFOV = _defaultFOV;
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _targetFOV, _deChargeLerpSpeed * Time.deltaTime);
            if (Mathf.Round(_camera.fieldOfView) >= _targetFOV)
                _disposable.Clear();
        }).AddTo(_disposable);
    }
}