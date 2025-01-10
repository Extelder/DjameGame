using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeTravel : MonoBehaviour
{
    [SerializeField] private KeyCode _travelKey;

    private bool _travelling;

    public event Action TravelStart;

    private void Update()
    {
        if (Input.GetKeyDown(_travelKey) && !_travelling)
        {
            TravelStart?.Invoke();
            _travelling = true;
        }
    }

    public void PerformTravel()
    {
    }

    public void TravelEnd()
    {
        _travelling = false;
    }
}