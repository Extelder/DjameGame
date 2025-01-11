using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hintText;
    [SerializeField] private float _defaultTimeOnScreen = 4f;

    public static PlayerHint Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
        throw new Exception("PlayerHint over 1");
    }

    public void SendHint(string text)
    {
        SendHint(text, _defaultTimeOnScreen);
    }

    public void SendHint(string text, float timeOnScreen)
    {
        StopAllCoroutines();
        _hintText.enabled = true;
        _hintText.text = text;
        StartCoroutine(HideHint(timeOnScreen));
    }

    private IEnumerator HideHint(float timeToHide)
    {
        yield return new WaitForSeconds(timeToHide);
        _hintText.enabled = false;
    }
}