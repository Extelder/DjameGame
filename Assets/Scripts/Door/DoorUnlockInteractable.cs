using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlockInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Door _door;
    [SerializeField] private bool _destroyAfterInteract;

    public void Interact()
    {
        _door.UnLock();
        if (_destroyAfterInteract)
            Destroy(gameObject);
    }
}