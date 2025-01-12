using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggerSceneSwitch : MonoBehaviour
{
    [SerializeField] private int _sceneId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController PlayerController))
        {
            SceneManager.LoadScene(_sceneId);
            Destroy(gameObject);
        }
    }
}