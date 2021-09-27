using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcessHandler : MonoBehaviour
{
    [SerializeField] private WindowsDisplay _windowsDisplay;

    public event Action<bool> onGamePauseWasChanged;

    public void ChangeSettingsActive(bool _enabled)
    {
        _windowsDisplay.SetSettingsPanelActive(_enabled);
        onGamePauseWasChanged?.Invoke(_enabled);
    }

}
