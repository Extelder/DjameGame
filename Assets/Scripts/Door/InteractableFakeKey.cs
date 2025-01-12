using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFakeKey : MonoBehaviour, IInteractable
{
    [SerializeField] private string _popUp;
    public void Interact()
    {
        PopUp.Instance.SendPopUp(_popUp);
        Destroy(gameObject);
    }
}
