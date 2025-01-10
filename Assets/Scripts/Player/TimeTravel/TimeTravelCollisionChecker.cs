using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelCollisionChecker : MonoBehaviour
{
    [field: SerializeField] public GameObject Camera { get; private set; }

    public bool Detected;

    private void OnTriggerStay(Collider other)
    {
        Detected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Detected = false;
    }
}