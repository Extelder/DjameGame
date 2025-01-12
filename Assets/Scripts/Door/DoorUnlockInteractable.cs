using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlockInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Door _door;
    [SerializeField] private bool _destroyAfterInteract;
    [SerializeField] private string _popUp;

    public void Interact()
    {
        PopUp.Instance.SendPopUp(_popUp);
        _door.UnLock();
        if (_destroyAfterInteract)
            Destroy(gameObject);
    }
}