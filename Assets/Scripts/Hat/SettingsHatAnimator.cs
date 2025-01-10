using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SettingsHatAnimator : MonoBehaviour
{
    [SerializeField] private string _settingsAnimatorBoolName = "SettingsOpened";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Settings.Instance.Opened += OnSettingsOpened;
        Settings.Instance.Closed += OnSettingsClosed;
    }

    private void OnDisable()
    {
        Settings.Instance.Opened += OnSettingsOpened;
        Settings.Instance.Closed -= OnSettingsClosed;
    }

    private void OnSettingsOpened()
    {
        _animator.SetBool(_settingsAnimatorBoolName, true);
        Debug.Log("Settings Open");
    }

    private void OnSettingsClosed()
    {
        _animator.SetBool(_settingsAnimatorBoolName, false);
        Debug.Log("Settings Close");
    }
}