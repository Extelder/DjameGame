using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HatLooking : MonoBehaviour
{
    [SerializeField] private string _lookAnimatorBoolName = "Looking";
    [SerializeField] private KeyCode _lookKey;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_lookKey) && !Settings.Instance.Open)
        {
            _animator.SetBool(_lookAnimatorBoolName, true);
        }

        if (Input.GetKeyUp(_lookKey))
        {
            _animator.SetBool(_lookAnimatorBoolName, false);
        }
    }
}