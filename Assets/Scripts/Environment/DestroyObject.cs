using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObject;

    public virtual void Destroy()
    {
        for (int i = 0; i < _gameObject.Length; i++)
        {
            Destroy(_gameObject[i]);
        }
    } 
}
