using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelCollisionChecker : MonoBehaviour
{
    [field: SerializeField] public GameObject Camera { get; private set; }

    public bool Detected;

    private Collider _collider;

    private void OnTriggerStay(Collider other)
    {
        _collider = other;
        Detected = true;
    }

    private void Update()
    {
        if (Detected && !_collider)
        {
            Detected = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Detected = false;
    }
}