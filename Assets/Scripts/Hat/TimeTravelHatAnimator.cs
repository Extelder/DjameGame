using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TimeTravelHatAnimator : MonoBehaviour
{
    [SerializeField] private PlayerTimeTravel _travel;
    [SerializeField] private string _travelAnimatorTriggerName = "Travel";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _travel.TravelStart += OnTravelStared;
    }

    private void OnTravelStared()
    {
        _animator.SetTrigger(_travelAnimatorTriggerName);
    }

    public void TravelMoment()
    {
        _travel.PerformTravel();
    }

    public void TravelAnimationEnd()
    {
        _animator.ResetTrigger(_travelAnimatorTriggerName);
        _travel.TravelEnd();
    }

    private void OnDisable()
    {
        _travel.TravelStart -= OnTravelStared;
    }
}