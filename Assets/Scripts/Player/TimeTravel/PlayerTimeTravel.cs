using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class PlayerTimeTravel : MonoBehaviour
{
    [SerializeField] private TimeTravelCollisionChecker _underChecker;
    [SerializeField] private TimeTravelCollisionChecker _upperChecker;

    [SerializeField] private Transform _player;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private float _yTravelOffset = 3.5f;
    [SerializeField] private string _obstaclePopUp;

    [SerializeField] private KeyCode _travelKey;

    public bool Travelling { get; private set; }

    private TimeTravelCollisionChecker _currentCollisionChecker;

    public event Action TravelStart;

    private void Awake()
    {
        _currentCollisionChecker = _upperChecker;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_travelKey) && !Travelling && !_currentCollisionChecker.Detected &&
            Settings.Instance.Open == false)
        {
            TravelStart?.Invoke();
            _controller.enabled = false;
            Travelling = true;
        }

        if (Input.GetKeyDown(_travelKey) && _currentCollisionChecker.Detected)
        {
            PopUp.Instance.SendPopUp(_obstaclePopUp);
        }
    }

    public void PerformTravel()
    {
        _player.position = new Vector3(_player.position.x, _player.position.y + _yTravelOffset, _player.position.z);
        _yTravelOffset = -_yTravelOffset;

        _underChecker.Camera.SetActive(!_underChecker.Camera.activeSelf);
        _upperChecker.Camera.SetActive(!_upperChecker.Camera.activeSelf);

        if (_yTravelOffset > 0)
        {
            _currentCollisionChecker = _upperChecker;
        }
        else
        {
            _currentCollisionChecker = _underChecker;
        }
    }

    public void TravelEnd()
    {
        Travelling = false;
        _controller.enabled = true;
    }
}