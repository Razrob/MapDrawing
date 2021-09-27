using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;

    private void Start()
    {
        SetSettingsPanelActive(false);
    }

    public void SetSettingsPanelActive(bool _enabled)
    {
        _settingsPanel.SetActive(_enabled);
    }
}
