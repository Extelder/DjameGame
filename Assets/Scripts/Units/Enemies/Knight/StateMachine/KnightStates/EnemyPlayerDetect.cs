using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetect : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _distanceOfDetection;
    public float Distance { get; private set; }
    public event Action PlayerDetected;
    public event Action PlayerLost;

    private void Update()
    {
        Distance = Vector3. Distance(transform.position, _player.transform.position); 

        if (Distance <= _distanceOfDetection)
        {
            PlayerDetected?.Invoke();
        }
        else
        {
            PlayerLost?.Invoke();
        }
    }
}
