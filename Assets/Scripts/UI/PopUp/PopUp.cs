using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject _popUpPanel;
    [SerializeField] private float _popUpScreenTime;
    [SerializeField] private Text _popUpText;

    public static PopUp Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError(gameObject);
        Debug.LogError("There`s one more PopUp");
        Debug.Break();
    }

    public void SendPopUp(string text)
    {
        StopAllCoroutines();
        _popUpText.text = text;
        _popUpPanel.SetActive(true);
        StartCoroutine(DisablePopUp());
    }

    private IEnumerator DisablePopUp()
    {
        yield return new WaitForSeconds(_popUpScreenTime);
        _popUpPanel.SetActive(false);
    }
}