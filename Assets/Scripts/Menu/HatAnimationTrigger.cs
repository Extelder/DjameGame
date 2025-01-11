using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator _hatAnimator;

    private void OnMouseEnter()
    {
        _hatAnimator.SetBool("MouseOn", true);
    }

    private void OnMouseExit()
    {
        _hatAnimator.SetBool("MouseOn", false);
    }
}