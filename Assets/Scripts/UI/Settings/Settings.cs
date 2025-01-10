using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private PlayerController _cameraModule;
    [SerializeField] private PlayerTimeTravel _timeTravel;

    [SerializeField] private Scrollbar _sensetivitySlider;
    [SerializeField] private Scrollbar _volumeSlider;

    public event Action Opened;
    public event Action Closed;

    public bool Open { get; private set; } = false;

    public static Settings Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError(gameObject);
        Debug.LogError("There`s one more settings");
        Debug.Break();
    }

    private void Start()
    {
        _sensetivitySlider.value = PlayerPrefs.GetFloat("Sensetivity", 2f) / 10;
        _cameraModule.lookSpeed = PlayerPrefs.GetFloat("Sensetivity", 2f);

        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1);
        _volumeSlider.value = AudioListener.volume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_timeTravel.Travelling)
        {
            _settingsCanvas.SetActive(!_settingsCanvas.activeSelf);
            Open = _settingsCanvas.activeSelf;
            if (_settingsCanvas.activeSelf)
            {
                Opened?.Invoke();
            }
            else
            {
                Closed?.Invoke();
            }
        }
    }

    public void OnSensetivitySliderValueChanged(float value)
    {
        _cameraModule.lookSpeed = value * 10f;
        PlayerPrefs.SetFloat("Sensetivity", _cameraModule.lookSpeed);
    }

    public void OnSoundSliderValueChanged(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
    }
}