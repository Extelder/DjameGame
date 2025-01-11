using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HatLooking : MonoBehaviour
{
    [SerializeField] private string _lookAnimatorBoolName = "Looking";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !Settings.Instance.Open)
        {
            _animator.SetBool(_lookAnimatorBoolName, true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _animator.SetBool(_lookAnimatorBoolName, false);
        }
    }
}