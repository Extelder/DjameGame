using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class PlayerTimeTravel : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Transform _travelPoint;

    [SerializeField] private KeyCode _travelKey;

    private bool _travelling;

    public event Action TravelStart;

    private void Update()
    {
        if (Input.GetKeyDown(_travelKey) && !_travelling)
        {
            TravelStart?.Invoke();
            _controller.enabled = false;
            _travelling = true;
        }
    }

    public void PerformTravel()
    {
        Vector3 tpPos = _travelPoint.position;
        _travelPoint.position = _player.position;
        _player.position = tpPos;
    }

    public void TravelEnd()
    {
        _travelling = false;
        _controller.enabled = true;
    }
}