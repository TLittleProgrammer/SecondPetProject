using UnityEngine;
using DG.Tweening;

public class MainUIManager : MonoBehaviour
{
    [Header("Main UI Text")]
    [SerializeField] private GameObject _mainUIText;
    [SerializeField] private Transform _mainUITextFirstPoint;
    [SerializeField] private Transform _mainUITextSecondPoint;
    [SerializeField] private float _durationHeading;

    [Header("Play Button")]
    [SerializeField] private GameObject _playButton;
    [SerializeField] private Transform _playButtonFirstPoint;
    [SerializeField] private Transform _playButtonSecondPoint;
    [SerializeField] private float _durationPlayButton;

    [Header("Settings Button")]
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private Transform _settingsButtonFirstPoint;
    [SerializeField] private Transform _settingsButtonSecondPoint;
    [SerializeField] private float _durationSettingsButton;

    [Header("Exit Button")]
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private Transform _exitButtonFirstPoint;
    [SerializeField] private Transform _exitButtonSecondPoint;
    [SerializeField] private float _durationExitButton;

    [Header("Settings Panel")]
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Transform _settingsFirstPoint;
    [SerializeField] private Transform _settingsSecondPoint;
    [SerializeField] private float _durationSettings;
    
    [Header("Settings Header Text")]
    [SerializeField] private GameObject _settingsHeaderText;
    [SerializeField] private Transform _settingsHeaderTextFirstPoint;
    [SerializeField] private Transform _settingsHeaderTextSecondPoint;
    [SerializeField] private float _durationSettingsHeaderText;

    public void TapSettings()
    {
        _mainUIText.transform.DOMoveY(_mainUITextSecondPoint.position.y, _durationHeading).SetEase(Ease.InOutQuint).OnComplete(TheAppearanceOfSettings);
        _playButton.transform.DOMoveY(_playButtonSecondPoint.position.y, _durationPlayButton);
        _settingsButton.transform.DOMoveX(_settingsButtonSecondPoint.position.x, _durationSettingsButton);
        _exitButton.transform.DOMoveX(_exitButtonSecondPoint.position.x, _durationExitButton);
    }

    private void TheAppearanceOfSettings()
    {
        _settingsPanel.transform.DOMoveY(_settingsSecondPoint.position.y, _durationSettings);
        _settingsHeaderText.transform.DOMoveX(_settingsHeaderTextSecondPoint.position.x, _durationSettingsHeaderText);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
